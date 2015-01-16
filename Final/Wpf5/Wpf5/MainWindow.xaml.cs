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
using Wpf5.window;
using System.Threading;
using System.Diagnostics;

namespace Wpf5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static TextBox text_box;
        private static TextBlock text_block;
        private static String text_block_string;
        private static Status status_window;
        private static Boolean tab_press_now;

        public MainWindow()
        {
            InitializeComponent();
            status_window = new Status();
            status_window.Show();

            text_box = (TextBox)FindName("xmal_text_box");
            text_block = (TextBlock)FindName("xmal_text_block");
            text_block_string = "";

            //text_box enter key handler
            text_box.KeyDown += new KeyEventHandler(textBoxKeyDown);

            //double tabbing
            tab_press_now = false;

            //Thread
            Alpha oAlpha = new Alpha();
            Thread oThread = new Thread(new ThreadStart(oAlpha.Beta));
            oThread.Start();
        }

        //text box key down handler
        public static void textBoxKeyDown(object sender, KeyEventArgs e)
        {
            String current_string;

            current_string = text_box.Text;

            if (e.Key == Key.Enter)
            {
                text_block_string += current_string + "\n";
                text_block.Text = text_block_string;
                text_box.Text = "";
            }
            else if (e.Key == Key.Tab)
            {
                if (tab_press_now)
                {
                    text_block_string += current_string + "\n";
                    text_block.Text = text_block_string + "tab\n";
                }
                tab_press_now = true;
            }
        }

        private void xmal_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            //status_window.UpdateText(text_box.GetLineText(0));
        }

        public class Alpha
        {
            public void Beta()
            {
                int i = 0;
                while (true)
                {
                    if (i > 1000000000)
                    {
                        tab_press_now = false;
                        i = 0;
                    }
                    i++;
                }
            }
        };
    }
}
