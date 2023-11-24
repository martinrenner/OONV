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
        private Order Context { get; set; }

        public OrderingState(Order context) {
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
            Console.WriteLine("- Choose Your Pizza ------------------------------------------");

            while (true)
            {
                string? pizza = GetValidPizzaInput(pizzeria);
                if (string.IsNullOrWhiteSpace(pizza))
                {
                    if (Context.Price == 0)
                    {
                        Console.WriteLine("No pizza selected. Please choose valid pizza.");
                        continue;
                    }
                    else
                        break;
                }
                MenuItem item = pizzeria.Menu.GetMenuItemByName(pizza);
                Context.AddItemToOrder(item);
            }

            Console.WriteLine("- Total Price ------------------------------------------------");
            Console.WriteLine($"Total price is {Context.Price:C}");
            Context.SetState(new OrderPaymentState(Context));
        }

        public void OrderPaymentDetails(Pizzeria pizzeria)
        {
            throw new Exception("Cannot pay order. Order has not been accepted yet.");
        }

        public void PrepareOrder(Pizzeria pizzeria)
        {
            throw new Exception("Cannot start preparation. Order has not been accepted yet.");
        }

        public void OrderReady()
        {
            throw new Exception("Cannot finish preparation. Order is not in preparation state.");
        }

        private string? GetValidPizzaInput(Pizzeria pizzeria)
        {
            string? pizza;
            do
            {
                Console.Write("Enter the name of the pizza (or press Enter to finish): ");
                pizza = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(pizza))
                    break;

                if (pizzeria.Menu.GetMenuItemByName(pizza) == null)
                    Console.WriteLine("Pizza is not on our menu!");
                else {
                    Console.WriteLine("Pizza added to order!");
                    break;
                }
                    
            } while (true);

            return pizza;
        }
    }
}
