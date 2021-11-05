using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Whitestone.OpenSerialPortMonitor.Main.Messages;

namespace Whitestone.OpenSerialPortMonitor.Main.Views
{
    /// <summary>
    /// Interaction logic for SerialDataView.xaml
    /// </summary>
    public partial class SerialDataView : UserControl
    {
        public SerialDataView()
        {
            InitializeComponent();

            DataViewParsed.TextChanged += TextChanged;
            DataViewRaw.TextChanged += TextChanged;
        }

        void TextChanged(object sender, TextChangedEventArgs e)
        {
            ScrollViewer scrollviewer;
            TextBox textbox = (TextBox)sender;
            if (textbox.Parent is Grid)
            {
                Grid grid = (Grid)textbox.Parent;
                scrollviewer = (ScrollViewer)grid.Parent;
            }
            else
            {
                scrollviewer = (ScrollViewer)textbox.Parent;
            }

            bool isAutoscroll = true;
            if (scrollviewer.Tag != null &&
                scrollviewer.Tag is bool)
            {
                isAutoscroll = (bool)scrollviewer.Tag;
            }

            if (isAutoscroll)
            {
                scrollviewer.ScrollToEnd();
            }   
        }
        

        private void DataViewParsed_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataViewSelected_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Limpiar(object sender, RoutedEventArgs e)
        {
            DataViewParsed.Text = "";
            DataViewHex.Text = "";
        }

        private void Button_Copy_Brix(object sender, RoutedEventArgs e)
        {
            string textToDelete = "Concentraci?n de az?car (correc.-CO2): "; //Aquí se escribe lo que se eliminará del resultado final al copiar
            string textToDelete2 = " ?Brix";
            string[] separatedData = DataViewParsed.Text.Split(
                    new string[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                );
            //separatedData se separó en un array, posteriormente se copia a portapapeles descartando textToDelete y texttoDelete2
            Clipboard.SetText(separatedData[0].Replace(textToDelete,"").Replace(textToDelete2, ""));
        }

        private void Button_Copy_CO2(object sender, RoutedEventArgs e)
        {
            string textToDelete = "Concentraci?n de CO2: ";
            string textToDelete2 = " vol.";
            string[] separatedData = DataViewParsed.Text.Split(
                    new string[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                );
            Clipboard.SetText(separatedData[1].Replace(textToDelete, "").Replace(textToDelete2, ""));
        }

        private void Button_Copy_ACC(object sender, RoutedEventArgs e)
        {
            string textToDelete = "Dieta con color [%]: ";
            string textToDelete2 = " %";
            string[] separatedData = DataViewParsed.Text.Split(
                    new string[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                );
            Clipboard.SetText(separatedData[3].Replace(textToDelete, "").Replace(textToDelete2, ""));
        }

        private void Button_Copy_ASC(object sender, RoutedEventArgs e)
        {
            string textToDelete = "Dieta-UV sin color [%]: ";
            string textToDelete2 = " %";
            string[] separatedData = DataViewParsed.Text.Split(
                    new string[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                );
            Clipboard.SetText(separatedData[2].Replace(textToDelete, "").Replace(textToDelete2, ""));
        }
    }
}
