using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATMSimulator.Model.Enum;

namespace ATMSimulator
{
    public static class History
    {
        public static Operation operationPerformed = Operation.None;
        public static float transactionAmount = 0;
        public static AccountType sourceAccount = AccountType.NotSpecified;
        public static AccountType destinationAccount = AccountType.NotSpecified;

        public static void clearHistory() {
            operationPerformed = Operation.None;
            sourceAccount = AccountType.NotSpecified;
            destinationAccount = AccountType.NotSpecified;
            transactionAmount = 0;
        }    
    }

}
