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

namespace Novel
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public static String path;

        public SettingsWindow()
        {
            InitializeComponent();

            //path to file
            String application_directory = System.AppDomain.CurrentDomain.BaseDirectory;
            path = application_directory + "options";

            //Init status
            side_bar_check_box.IsChecked = true;
        }

        //Close
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Set the checkbox
        //Make options file if its not there
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String raw = sr.ReadLine();
                    String[] raws = raw.Split('=');
                    if (raws[1].Equals("false"))
                    {
                        side_bar_check_box.IsChecked = false;
                    }
                    else if (raws[1].Equals("true"))
                    {
                        side_bar_check_box.IsChecked = true;
                    }

                }
            }
        }

        //Options OK
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (StreamWriter outfile = new StreamWriter(path))
            {
                if (side_bar_check_box.IsChecked == true)
                {
                    outfile.Write("expand_side_bar=true");
                }
                else
                {
                    outfile.Write("expand_side_bar=false");
                }
            }
            this.Close();
        }
    }
}
