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

namespace Wpf5.window
{
    /// <summary>
    /// Interaction logic for Status.xaml
    /// </summary>
    public partial class Status : Window
    {
        private static TextBlock status_text_block;

        public Status()
        {
            InitializeComponent();
            status_text_block = (TextBlock)xmal_status_text_block;
        }

        public void UpdateText(String text)
        {
            xmal_status_text_block.Text = text;
        }
    }
}
