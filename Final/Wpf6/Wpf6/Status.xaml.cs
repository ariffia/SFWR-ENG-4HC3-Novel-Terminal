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
    /// Interaction logic for Status.xaml
    /// </summary>
    public partial class Status : Window
    {
        public Status()
        {
            InitializeComponent();
        }

        public void UpdateText(String text) {
            status_text_block.Text = text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String application_directory = System.AppDomain.CurrentDomain.BaseDirectory;
            String path = application_directory + "TextFile.txt";
            if (File.Exists(path))
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.Write("expand_side_bar=true");
                }
                using (StreamReader sr = new StreamReader(path))
                {
                    status_text_block.Text = sr.ReadLine();
                }
            }
        }

        //Moving grid splitter
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            String application_directory = System.AppDomain.CurrentDomain.BaseDirectory;
            String path = application_directory + "TextFile.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.Write("expand_side_bar=false");
                }
            }
        }
    }
}
