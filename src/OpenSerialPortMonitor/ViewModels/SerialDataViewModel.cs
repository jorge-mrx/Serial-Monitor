﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using Whitestone.OpenSerialPortMonitor.Main.Messages;
using Whitestone.OpenSerialPortMonitor.SerialCommunication;

namespace Whitestone.OpenSerialPortMonitor.Main.ViewModels
{
    public class SerialDataViewModel : PropertyChangedBase, IHandle<SerialPortConnect>, IHandle<SerialPortDisconnect>, IHandle<Autoscroll>, IHandle<SerialPortSend>
    {
        private readonly IEventAggregator _eventAggregator;
        private SerialReader _serialReader;
        private Timer _cacheTimer;
        private int _rawDataCounter = 0;

        public SerialDataViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            _serialReader = new SerialReader();
        }

        private bool _isAutoscroll = true;
        public bool IsAutoscroll
        {
            get { return _isAutoscroll; }
            set
            {
                _isAutoscroll = value;
                NotifyOfPropertyChange(() => IsAutoscroll);
            }
        }

        private StringBuilder _dataViewParsedBuilder = new StringBuilder();
        private string _dataViewParsed = string.Empty;

        private bool locked = false;
        //string[] selectedData = { "Pablo", "Jorge" };
        //string[] separatedData = { "", "", "", "", "", "", "", "" };
        public string DataViewParsed
        {
            get { return _dataViewParsed; }
            set
            {
                // Averigué que el tipo de variable _dataviewParsed es un string, hay que separar ese string por cada salto de línea para elegir 
                //cuales se podrán ver y cuales no
                //string[] separatedData = _dataViewParsed.Split(' ');

                //Crea un array de strings al separarlos por salto de línea
                //System.Console.WriteLine(separatedData.GetType());

                string[] separatedData = value.Split(
                    new string[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                );

                if (_dataViewParsed.Contains("Densidad") && _dataViewParsed.Contains("----------------------------------------"))
                {

                    value = "";
                    string message = "";

                    bool line0_show = true;
                    bool line1_show = true;
                    bool line2_show = true;
                    bool line3_show = true;

                    string line0 = separatedData[12];
                    string line1 = separatedData[8];
                    string line2 = separatedData[11];
                    string line3 = separatedData[9];


                    //La variable message es el resultado final que se mostrará en pantalla
                    //En la línea de abajo se escribe esa varaible agregando lo que queremos mostrar
                    if (line0_show) { message += "" + line0 + "\n"; }
                    if (line1_show) { message += "" + line1 + "\n"; }
                    if (line2_show) { message += "" + line2 + "\n"; }
                    if (line3_show) { message += "" + line3 + "\n"; }



                    //message += "***********************************\n";
                    value = message;



                    //Console.WriteLine(message);
                    //Console.WriteLine(separatedData[1]);
                    //Console.WriteLine(DataViewParsed.GetType());
                    _dataViewParsed = value;
                }
                
                _dataViewParsed = value;
                NotifyOfPropertyChange(() => DataViewParsed);

            }
        }

        private StringBuilder _dataViewRawBuilder = new StringBuilder();
        private string _dataViewRaw = string.Empty;
        public string DataViewRaw
        {
            get { return _dataViewRaw; }
            set
            {
                //_dataViewRaw = value;
                //NotifyOfPropertyChange(() => DataViewRaw);
            }
        }

        private StringBuilder _dataViewHexBuilder = new StringBuilder();
        private string _dataViewHex = string.Empty;
        public string DataViewHex
        {
            get { return _dataViewHex; }
            set
            {
                //_dataViewHex = value;
                //NotifyOfPropertyChange(() => DataViewHex);
            }
        }

        public void Handle(SerialPortConnect message)
        {
            try
            {
                _cacheTimer = new Timer();
                _cacheTimer.Interval = 500;
                _cacheTimer.Elapsed += _cacheTimer_Elapsed;
                _cacheTimer.Start();

                _serialReader.Start(message.PortName, message.BaudRate, message.Parity, message.DataBits, message.StopBits);
                _serialReader.SerialDataReceived += SerialDataReceived;

            }
            catch (Exception ex)
            {
                _eventAggregator.PublishOnUIThread(new ConnectionError() { Exception = ex });
            }
        }

        public void Handle(SerialPortDisconnect message)
        {
            _cacheTimer.Stop();

            _serialReader.Stop();
        }

        void _cacheTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string dataParsed = _dataViewParsedBuilder.ToString();
            _dataViewParsedBuilder = new StringBuilder();

            string dataHex = _dataViewHexBuilder.ToString();
            _dataViewHexBuilder = new StringBuilder();

            string dataRaw = _dataViewRawBuilder.ToString();
            _dataViewRawBuilder = new StringBuilder();

            DataViewParsed += dataParsed;
            DataViewHex += dataHex;
            DataViewRaw += dataRaw;
        }

        public void Handle(Autoscroll message)
        {
            IsAutoscroll = message.IsTurnedOn;
        }

        void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            _dataViewParsedBuilder.Append(System.Text.Encoding.ASCII.GetString(e.Data));

            foreach (byte data in e.Data)
            {
                _rawDataCounter = _rawDataCounter + 1;

                char character = (char)data;
                if (data <= 31 ||
                    data == 127)
                {
                    character = '.';
                }

                _dataViewHexBuilder.Append(string.Format("{0:x2} ", data));
                _dataViewRawBuilder.Append(character);

                if (_rawDataCounter > 0 && _rawDataCounter % 16 == 15)
                {
                    _dataViewHexBuilder.Append("\r\n");
                    _dataViewRawBuilder.Append("\r\n");
                    _rawDataCounter = 0;
                }
            }
        }

        public void Handle(SerialPortSend message)
        {
            _serialReader.Send(message.Data);
        }
    }
}
