using OONV.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class OrderIntroductionState : IOrderState
    {
        public void PizzeriaIntro(Order context, Pizzeria pizzeria)
        {
            Console.Clear();
            Console.WriteLine("Welcome to " + pizzeria.PizzeriaName);
            Console.WriteLine(pizzeria.PizzeriaAddress.GetAddress());
            Console.WriteLine("- Our Menu ---------------------------------------------------");
            pizzeria.Menu.DisplayMenu();
            context.CurrentState = new OrderingState();
        }

        public void OrderDetails(Order context, Pizzeria pizzeria)
        {
            Console.WriteLine("Cannot accept order. Order has not started yet.");
        }

        public void OrderPaymentDetails(Order context, Pizzeria pizzeria)
        {
            Console.WriteLine("Cannot pay order. Order has not started yet.");
        }

        public void PrepareOrder(Order context, Pizzeria pizzeria)
        {
            Console.WriteLine("Cannot start preparation. Order has not been accepted yet.");
        }

        public void OrderReady(Order context)
        {
            Console.WriteLine("Cannot finish preparation. Order has not been accepted yet.");
        }
    }
}
