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

namespace ATMSimulator.SimulatedInput
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class InsertCardWindow : Window
    {
        public static string cardNumber = ""    ;

        public InsertCardWindow()
        {
            InitializeComponent();
        }

        private void InsertCard_Click(object sender, RoutedEventArgs e)
        {
            TextBox textbox = FindName("CardNumberField") as TextBox;
            cardNumber = textbox.Text;
            this.Close();
        }


    }
  
}
