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
using ATMSimulator.SimulatedInput;

namespace ATMSimulator.Pages
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class InsertCardPage : UserControl
    {
        private int Attempts;

        public InsertCardPage()
        {
            InitializeComponent();
            Attempts = 0;
        }

        private void InsertCard_Click(object sender, RoutedEventArgs e)
        {
            InsertCardWindow insertSimulator = new InsertCardWindow();
            if (insertSimulator.ShowDialog()==false)
            {
                //Only shows as correct if 1234567812345678
                if (InsertCardWindow.cardNumber.Trim().Equals("1234567812345678"))
                {
                    LoginPage loginPage = new LoginPage();
                    this.Content = loginPage;
                } 
                else
                {
                    TextBlock errorField = FindName("CardReadErrorLabel") as TextBlock;
                    errorField.Text = "There was an error reading your card. Please try again or talk to an agent for assistance.";
                }
            }
        }

    }
}
