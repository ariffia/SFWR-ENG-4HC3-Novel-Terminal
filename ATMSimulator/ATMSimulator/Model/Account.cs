using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMSimulator.Model.Enum;

namespace ATMSimulator.Model
{
    public class Account
    {
        static User[] Users;

        private uint Id { get; set; }
        private AccountType AccountType { get; set; }
        private ulong Balence { get; set; }
        private static Account[] Accounts;

        public Account(uint userId, AccountType accountType, ulong balence)
        {
            bool enteredIntoArray = false;
            int i = 0;
            this.AccountType = accountType;
            this.Balence = balence;

            //Enter into Account Array
            while (!enteredIntoArray)
            {
                if (Accounts[i] != null)
                {
                    Accounts[i] = this;
                    this.Id = (uint) i;

                    //complete loop
                    enteredIntoArray = true;
                }

                i++;
            }
        }

        public void InstantiateAccounts ()
        {
            Accounts = new Account[20];
        }
    }
}