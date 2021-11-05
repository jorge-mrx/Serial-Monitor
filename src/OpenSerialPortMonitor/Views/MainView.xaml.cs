using System;
using System.Collections.Generic;
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

using System.IO;

namespace Whitestone.OpenSerialPortMonitor.Main.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {   
        public MainView()
        {
            //string filePath = @"C:\test.txt";
            //string filePath2 = @"~\App_Data";
            string app_data_path = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            string[] pre_path = { @"", app_data_path, "OSPM", "license.lic" };
            string path = System.IO.Path.Combine(pre_path);

            if (File.Exists(path))
            {
                List<string> lines = File.ReadAllLines(path).ToList();
                string license = lines[0];

                if (license == "f4lEdB*VTBs&")
                {
                    Console.WriteLine("La licencia es válida");
                }
                else
                {
                    Console.WriteLine("La licencia es inválida");
                    MessageBox.Show("La licencia ha caducado");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("La licencia ha caducado");
                this.Close();
            }
            InitializeComponent();
        }

        public void chk_id_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("asd");
            string algo = "xasd";
        }
    }
}
