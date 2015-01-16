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
    /// Interaction logic for DestroyCardPage.xaml
    /// </summary>
    public partial class DestroyCardPage : UserControl
    {
        public DestroyCardPage()
        {
            InitializeComponent();
        }

        private void EndSession_Handler(object sender, RoutedEventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            this.Content = welcomePage;
        }
    }
}
