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

namespace ATMSimulator.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        private int attempts; //Number of failed PIN attempts

        public LoginPage () 
        {
            InitializeComponent();
        }

        /* Meant for buttons that append text for a textbox 
         */
        void appendToTextbox_Click(object sender, RoutedEventArgs e)
        {
            //Reference for getting info from button http://stackoverflow.com/questions/2006507/add-parameter-to-button-click-event
            TextBox textBox = FindName("PINInput") as TextBox;
            textBox.Text = textBox.Text += ((Button)sender).Tag;
        }

        /* Meant for PIN input, restricts to max 4 characters and uses stars
         */
        void appendToPINBox_Click(object sender, RoutedEventArgs e)
        {
            PasswordBox PINBox = FindName("PINInput") as PasswordBox;
            if (PINBox.Password.Length < PINBox.MaxLength)
                PINBox.Password = PINBox.Password += ((Button)sender).Tag;
            else 
            {
                //SHOW FEEDBACK THAT FIELD IS FULL
            }
        }

        private void clearPIN_Click(object sender, RoutedEventArgs e)
        {
            PasswordBox PINBox = FindName("PINInput") as PasswordBox;
            PINBox.Password = "";
        }

        private void HandleInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }

        private void backspacePIN_Click(object sender, RoutedEventArgs e)
        {
            PasswordBox PINBox = FindName("PINInput") as PasswordBox;
            int fieldLength = PINBox.Password.Length;

            if (fieldLength > 0)
                PINBox.Password = PINBox.Password.Substring(0, fieldLength - 1);            
        }

        private void verifyPIN_Click(object sender, RoutedEventArgs e)
        {
            //The user information are hardcoded for presentation purposes
            PasswordBox PINBox = FindName("PINInput") as PasswordBox;
            if (PINBox.Password.Equals("1234"))
            {
                MainMenu mainMenu = new MainMenu();
                this.Content = mainMenu;
            }
            else
            {
                attempts++;
                TextBlock errorLabel = FindName("PINErrorLabel") as TextBlock;
                errorLabel.Foreground = Brushes.Red;

                switch (attempts)
                {
                    case 1:
                        errorLabel.Text = "One unsuccessful PIN submitted, two tries remaining";
                        break;
                    case 2:
                        errorLabel.Text = "Two unsuccessful PIN submitted, one try remaining";
                        break;
                    case 3:
                        DestroyCardPage nextPage = new DestroyCardPage();
                        this.Content = nextPage;
                        break;
                    default:
                        //LOG ERROR
                        break;
                }

                PINBox.Password = "";
            }
        }

        private void EndSession_Click(object sender, RoutedEventArgs e)
        {
            RemoveCardPage page = new RemoveCardPage();
            this.Content = page;
        }
    }
}
