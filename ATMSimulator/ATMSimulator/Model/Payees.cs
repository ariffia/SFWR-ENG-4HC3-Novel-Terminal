using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator.Model
{
    public class Payees
    {
        Payee[] payees = { new Payee(), new Payee(), new Payee(), new Payee(), new Payee() };
    }

    public class Payee
    {
        public bool status { get; set; }
        public String name { get; set; }
        public int number { get; set; }

        public Payee()
        {
            this.status = false;
            this.name = "fido";
            this.number = 1234567890;
        }
    }
}
