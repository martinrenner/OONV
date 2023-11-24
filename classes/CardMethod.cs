using OONV.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class CardMethod : IPaymentStrategy
    {
        public bool ProcessPayment(double amount)
        {
            Console.WriteLine("Swiping the card...");
            Thread.Sleep(2000);

            Random random = new Random();
            bool isPaymentSuccessful = random.Next(0, 2) == 0;

            if (isPaymentSuccessful)
            { 
                Console.WriteLine($"Payment of {amount:C} processed successfully with credit card.");
                return true;
            }
            else
            { 
                Console.WriteLine("Payment failed. Please try again or use a different payment method.");
                return false;
            }
        }
    }
}
