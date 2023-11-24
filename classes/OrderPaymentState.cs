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
        private Order Context { get; set; }

        public OrderPaymentState(Order context) {
            Context = context;
        }

        public void SetContext(Order context)
        {
            Context = context;
        }

        public void PizzeriaIntro(Pizzeria pizzeria)
        {
            throw new Exception("Cannot start new order when old is unfinished.");
        }

        public void OrderDetails(Pizzeria pizzeria)
        {
            throw new Exception("Cannot accept the order. It's already in preparation.");
        }

        public void OrderPaymentDetails(Pizzeria pizzeria)
        {
            Console.WriteLine("- Payment Details --------------------------------------------");

            bool paymentSuccessful = false;
            do
            {
                string method = GetValidPaymentMethodInput();
                Context.SetPaymentStrategy(method.ToLower() == "card" ? new CardMethod() : new CashMethod());
                paymentSuccessful = Context.DoPaymentStrategy(Context.Price);
            } while (!paymentSuccessful);
            Context.Notify("Your order has been accepted");
            Context.SetState(new OrderPreparationState(Context));
        }

        public void PrepareOrder(Pizzeria pizzeria)
        {
            throw new Exception("Cannot prepare the order. It's not paid.");
        }

        public void OrderReady()
        {
            throw new Exception("Order preparation finished.");
        }

        private string GetValidPaymentMethodInput()
        {
            string? method;
            do
            {
                Console.Write("Cash or Card? ");
                method = Console.ReadLine()?.Trim().ToLower();

                if (method != "cash" && method != "card")
                    Console.WriteLine("Invalid payment method. Please enter 'cash' or 'card'.");
                else
                    break;
            } while (true);

            return method;
        }
    }
}
