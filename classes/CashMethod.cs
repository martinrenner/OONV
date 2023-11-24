using OONV.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class CashMethod : IPaymentStrategy
    {
        public bool ProcessPayment(double amount)
        {
            Console.WriteLine("Searching for the wallet...");
            Thread.Sleep(1500);
            Console.WriteLine("Wallet found!");
            Thread.Sleep(2000);
            Console.WriteLine("Payment successful!");
            return true;
        }
    }
}
