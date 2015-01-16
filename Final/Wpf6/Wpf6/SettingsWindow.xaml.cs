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
using System.Windows.Shapes;
using System.IO;

namespace Wpf6
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String application_directory = System.AppDomain.CurrentDomain.BaseDirectory;
            String path = application_directory + "TextFile.txt";
            if (true)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    if (check_box_1.IsChecked == true)
                    {
                        outfile.Write("expand_side_bar=true");
                    }
                    else
                    {
                        outfile.Write("expand_side_bar=false");
                    }
                }
            }
            this.Close();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            String application_directory = System.AppDomain.CurrentDomain.BaseDirectory;
            String path = application_directory + "TextFile.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String raw = sr.ReadLine();
                    String[] raws = raw.Split('=');
                    if (raws[1].Equals("false"))
                    {
                        check_box_1.IsChecked = false;
                    }
                    else if (raws[1].Equals("true"))
                    {
                        check_box_1.IsChecked = true;
                    }

                }
            }
        }
    }
}
