using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMSimulator.Model
{
    public class User
   {
        private static User[] Users;

        private uint Id { get; set; }

        private string FirstName { get; set; }
        private string LastName { get; set; }
        private uint ChequingAccountId { get; set; }
        private uint SavingAccountId { get; set; }

        //Constructor
        public User(string firstName, string lastName, uint cheqingAccId, uint savingAccId)
        {
            bool enteredIntoArray = false;
            int i = 0;

            this.FirstName = firstName;
            this.LastName = lastName;
            this.ChequingAccountId = cheqingAccId;
            this.SavingAccountId = savingAccId;

            //Enter into array and give it a unique Id = to array index
            while (!enteredIntoArray)
            {
                if (Users[i] != null)
                {
                    Users[i] = this;
                    this.Id = (uint) i;

                    //complete loop
                    enteredIntoArray = true;
                }

                i++;
            }
        }

        public void InstantiateUsers ()
        {
            //Ensure Users array instantiated
            Users = new User[10];
        }
    }
}