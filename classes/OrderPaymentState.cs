using OONV.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class OrderPaymentState : IOrderState
    {
        public void PizzeriaIntro(Order context, Pizzeria pizzeria)
        {
            throw new Exception("Cannot start new order when old is unfinished.");
        }

        public void OrderDetails(Order context, Pizzeria pizzeria)
        {
            throw new Exception("Cannot accept the order. It's already in preparation.");
        }

        public void OrderPaymentDetails(Order context, Pizzeria pizzeria)
        {
            Console.WriteLine("- Payment Details --------------------------------------------");

            bool paymentSuccessful = false;
            do
            {
                string method = GetValidPaymentMethodInput();

                IPaymentStrategy strategy = method.ToLower() == "card" ? new CardMethod() : new CashMethod();
                paymentSuccessful = strategy.ProcessPayment(context.Price);

            } while (!paymentSuccessful);

            context.Notify("Your order has been accepted");
            context.CurrentState = new OrderPreparationState();
        }

        public void PrepareOrder(Order context, Pizzeria pizzeria)
        {
            throw new Exception("Cannot prepare the order. It's not paid.");
        }

        public void OrderReady(Order context)
        {
            throw new Exception("Order preparation finished.");
        }

        private string GetValidPaymentMethodInput()
        {
            string method;
            do
            {
                Console.Write("Cash or Card? ");
                method = Console.ReadLine()?.Trim().ToLower();

                if (method != "cash" && method != "card")
                {
                    Console.WriteLine("Invalid payment method. Please enter 'cash' or 'card'.");
                }
                else
                {
                    break;
                }
            } while (true);

            return method;
        }
    }
}
