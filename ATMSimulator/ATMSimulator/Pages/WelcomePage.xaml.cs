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
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class WelcomePage : UserControl
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        void Proceed_Click(object sender, RoutedEventArgs e)
        {
            InsertCardPage insertCardPage = new InsertCardPage();
            this.Content = insertCardPage;
        }

        //will add border to the button
        //works for all buttons
        void ChangeLanguage_Click(object sender, RoutedEventArgs e)
        {
            //Should make the button look darker if selected
            ClearBorders();
            Button button = (Button)sender;
            button.BorderThickness = new Thickness(3, 3, 3, 3);
        }

        //clear all borders for all the language buttons on the welcome page
        void ClearBorders()
        {
            String[] buttons = { "english_button", "deutsch_button", "francais_button", "svenska_button",
                               "arabic_button", "arabic2_button", "jap_button", "jap2_button"};
            for (int i = 0; i < buttons.Length; i++)
            {
                Button button = (Button)FindName(buttons[i]);
                button.BorderThickness = new Thickness(1, 1, 1, 1);
            }
        }
    }
}
