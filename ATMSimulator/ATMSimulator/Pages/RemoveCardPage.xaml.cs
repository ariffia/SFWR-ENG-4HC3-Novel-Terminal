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

namespace ATMSimulator.Pages
{
    /// <summary>
    /// Interaction logic for RemoveCardPage.xaml
    /// </summary>
    public partial class RemoveCardPage : UserControl
    {
        public RemoveCardPage()
        {
            InitializeComponent();
        }

        private void RemoveCard_Event (object sender, RoutedEventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            this.Content = welcomePage;
        }
    }
}
