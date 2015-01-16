﻿using System;
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
using System.Media;

namespace ATMSimulator.Pages
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class DepositPage : UserControl
    {
        public DepositPage()
        {
            InitializeComponent();
            History.clearHistory();
        }

        private void SelectAccount_Click(object sender, RoutedEventArgs e)
        {
            Button source = (Button)sender;
            //source.IsEnabled = false;

            string tagText = (string)source.Tag;

            //Enable other button
            Button savingButton = FindName("FromSavingButton") as Button;
            Button chequingButton = FindName("FromChequingButton") as Button;
            if (tagText.IndexOf("Chequing") > -1)
            {
                
                //savingButton.IsEnabled = true;
                History.destinationAccount = AccountType.Chequing;

                //borders
                savingButton.BorderThickness = new Thickness(1, 1, 1, 1);
                chequingButton.BorderThickness = new Thickness(3, 3, 3, 3);
            }
            else
            {
                //chequingButton.IsEnabled = true;
                History.destinationAccount = AccountType.Saving;

                //borders
                savingButton.BorderThickness = new Thickness(3, 3, 3, 3);
                chequingButton.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            updateNotificationText();
        }

        /* Meant for buttons that append text for a textbox 
 */
        void AppendToTextbox_Click(object sender, RoutedEventArgs e)
        {
            //Reference for getting info from button http://stackoverflow.com/questions/2006507/add-parameter-to-button-click-event
            TextBox textBox = FindName("TransactionAmount") as TextBox;

            //Ensure no more than 2 number after decimal
            int decimalIndex = textBox.Text.IndexOf(".");

            if ((textBox.Text.Length - decimalIndex > 2) && (decimalIndex > -1))
                SystemSounds.Asterisk.Play();
            else if (textBox.Text.Length < 1)
            {
                textBox.Text = textBox.Text += ((Button)sender).Tag;
                History.transactionAmount = 0;
                updateNotificationText();
            }
            else
            {
                textBox.Text = textBox.Text += ((Button)sender).Tag;
                History.transactionAmount = Single.Parse(textBox.Text);
                updateNotificationText();
            }
                
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            TextBox textBox = FindName("TransactionAmount") as TextBox;
            textBox.Text = "";
            History.transactionAmount = 0f;
            updateNotificationText();
        }

        private void backspace_Click(object sender, RoutedEventArgs e)
        {
            TextBox textBox = FindName("TransactionAmount") as TextBox;
            int fieldLength = textBox.Text.Length;

            if (fieldLength > 1)
            {
                textBox.Text = textBox.Text.Substring(0, fieldLength - 1);

                History.transactionAmount = Single.Parse(textBox.Text);
                updateNotificationText();
            }
            else if (fieldLength == 1)
            {
                textBox.Text = textBox.Text.Substring(0, fieldLength - 1);
                History.transactionAmount = 0f;
                updateNotificationText();
            }
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            TextBox textBox = FindName("TransactionAmount") as TextBox;

            //Ensure no decimal already exists
            if (textBox.Text.IndexOf(".") == -1)
                if (textBox.Text.Length < 1)
                    textBox.Text = "0.";
                else
                    textBox.Text = textBox.Text += ".";
            else
            {
                SystemSounds.Asterisk.Play();
            }
        }

        private void updateNotificationText()
        {
            TextBlock notificationText = FindName("ConfirmationText") as TextBlock;
            Button confirm = FindName("ConfirmButton") as Button;

            if ((History.transactionAmount != 0) && (History.destinationAccount > AccountType.NotSpecified))
            {
                notificationText.Text = String.Concat("Do you want to deposit $", History.transactionAmount,
                    " account into your ", History.destinationAccount.ToString().ToLower(), "?");

                confirm.IsEnabled = true;
            }
            else if (History.transactionAmount != 0)
            {
                notificationText.Text = "Please select the destination account for deposit";
                confirm.IsEnabled = false;
            }
            else if (History.destinationAccount > AccountType.NotSpecified)
            {
                notificationText.Text = "Please select the amount you wish to deposit";
                confirm.IsEnabled = false;
            }
            else
            {
                notificationText.Text = "Please select a destination account and amount to deposit.";
                confirm.IsEnabled = false;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            History.clearHistory();

            MainMenu page = new MainMenu();
            this.Content = page;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (History.destinationAccount == AccountType.Chequing)
                ExampleUser.ChequingBalence += History.transactionAmount;
            else
                ExampleUser.SavingsBalence += History.transactionAmount;

            History.operationPerformed = Operation.Deposit;

            MainMenu page = new MainMenu();
            this.Content = page;
        }
    }
}
