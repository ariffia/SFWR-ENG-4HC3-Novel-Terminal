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

using ATMSimulator.Model.Enum;

namespace ATMSimulator.Pages
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public static Label notificationLabel;
        public static bool chequing_show = true;
        public static bool savings_show = true;

        public MainMenu()
        {
            InitializeComponent();

            //Prepare notification label for other pages to access in future
            notificationLabel = FindName("NotificationLabel") as Label;

            //Disable quick withdrawl button if no quick withdrawl amount exists
            if (ExampleUser.QuickWithdrawlAmount <= 0) {
                Button quickWithdrawlButton = FindName("QuickWithdrawlButton") as Button;
                quickWithdrawlButton.IsEnabled = false;
            }

            //If transfered from an operation then displays feedback
            TextBlock feedback = FindName("NotificationLabel") as TextBlock;

            switch(History.operationPerformed)
            {
                case Operation.Deposit:
                    feedback.Text = string.Concat("You have successfully deposited $", History.transactionAmount, " into your ",
                        History.destinationAccount.ToString().ToLower(), " account.");
                    break;
                case Operation.Withdraw:
                    feedback.Text = string.Concat("You have successfully withdrew $", History.transactionAmount, " from your ",
                        History.sourceAccount.ToString().ToLower(), " account.");
                    break;
                case Operation.Transfer:
                    feedback.Text = string.Concat("You have successfully transferred $", History.transactionAmount, " from your ",
                        History.sourceAccount.ToString().ToLower(), " account to your ", History.destinationAccount.ToString().ToLower(), " account.");
                    break;
                case Operation.PayBill:
                    //Highly doubt we will have time for this anyway
                    break;
                default:
                    //Do Nothing
                    break;
            }
        }

        private void ShowChequingBalence_Click(object sender, RoutedEventArgs e)
        {
            Button chequingButton = FindName("ChequingBalenceButton") as Button;
            //chequingButton.Visibility = System.Windows.Visibility.Collapsed;
            if (chequing_show)
            {
                chequingButton.Content = String.Concat("$", ExampleUser.ChequingBalence.ToString());
            }
            else
            {
                chequingButton.Content = "Show";
            }
            chequing_show = !chequing_show;

            //TextBlock balenceLabel = FindName("ChequingBalenceLabel") as TextBlock;
            //balenceLabel.Text = String.Concat("$", ExampleUser.ChequingBalence.ToString());
            //balenceLabel.Visibility = System.Windows.Visibility.Visible;
        }

        private void ShowSavingBalence_Click(object sender, RoutedEventArgs e)
        {
            Button savingsButton = FindName("SavingsBalenceButton") as Button;
            if (savings_show)
            {
                savingsButton.Content = String.Concat("$", ExampleUser.SavingsBalence.ToString());
            }
            else
            {
                savingsButton.Content = "Show";
            }
            savings_show = !savings_show;

            //Button savingsButton = FindName("SavingsBalenceButton") as Button;
            //savingsButton.Visibility = System.Windows.Visibility.Collapsed;

            //TextBlock balenceLabel = FindName("SavingsBalenceLabel") as TextBlock;
            //balenceLabel.Text = String.Concat("$", ExampleUser.SavingsBalence.ToString());
            //balenceLabel.Visibility = System.Windows.Visibility.Visible;
        }

        private void PayBills_Click(object sender, RoutedEventArgs e)
        {
            PayBillPage page = new PayBillPage();
            this.Content = page;
        }

        private void ManagePayees_Click(object sender, RoutedEventArgs e)
        {
            PayeeManagementPage page = new PayeeManagementPage();
            this.Content = page;
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingPage page = new SettingPage();
            this.Content = page;
        }

        private void Deposit_Click(object sender, RoutedEventArgs e)
        {
            DepositPage page = new DepositPage();
            this.Content = page;
        }

        private void Withdrawl_Click(object sender, RoutedEventArgs e)
        {
            WithdrawlPage page = new WithdrawlPage();
            this.Content = page;
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            TransferPage page = new TransferPage();
            this.Content = page;
        }

        private void QuickWithdrawl_Click(object sender, RoutedEventArgs e)
        {
            SettingPage page = new SettingPage();
            this.Content = page;
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            RemoveCardPage page = new RemoveCardPage();
            this.Content = page;
        }
    }
}
