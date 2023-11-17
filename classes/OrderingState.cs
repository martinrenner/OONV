using OONV.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class OrderingState : IOrderState
    {
        public void PizzeriaIntro(Order context, Pizzeria pizzeria)
        {
            Console.WriteLine("Cannot start new order when old is unfinished.");
        }

        public void OrderDetails(Order context, Pizzeria pizzeria)
        {
            Console.WriteLine("- Choose Your Pizza ------------------------------------------");

            while (true)
            {
                string pizza = GetValidPizzaInput(pizzeria);
                if (string.IsNullOrWhiteSpace(pizza))
                    break;
                MenuItem item = pizzeria.Menu.GetMenuItemByName(pizza);
                context.AddItemToOrder(item);
            }

            if (context.Price == 0)
            {
                Console.WriteLine("No pizza selected. Returning to Order Introduction state.");
                context.CurrentState = new OrderIntroductionState();
                return;
            }
            Console.WriteLine("- Total Price ------------------------------------------------");
            Console.WriteLine($"Total price is {context.Price:C}");
            context.CurrentState = new OrderPaymentState();
        }

        public void OrderPaymentDetails(Order context, Pizzeria pizzeria)
        {
            Console.WriteLine("Cannot pay order. Order has not been accepted yet.");
        }

        public void PrepareOrder(Order context, Pizzeria pizzeria)
        {
            Console.WriteLine("Cannot start preparation. Order has not been accepted yet.");
        }

        public void OrderReady(Order context)
        {
            Console.WriteLine("Cannot finish preparation. Order is not in preparation state.");
        }

        private string GetValidPizzaInput(Pizzeria pizzeria)
        {
            string pizza;
            do
            {
                Console.Write("Enter the name of the pizza (or press Enter to finish): ");
                pizza = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(pizza))
                {
                    break;
                }

                if (pizzeria.Menu.GetMenuItemByName(pizza) == null)
                {
                    Console.WriteLine("Pizza is not on our menu!");
                }
                else
                {
                    break;
                }
            } while (true);

            return pizza;
        }
    }
}
