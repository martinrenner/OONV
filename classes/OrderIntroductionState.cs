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
        private Order Context { get; set; }

        public OrderIntroductionState(Order context) {
            Context = context;
        }

        public void SetContext(Order context)
        {
            Context = context;
        }

        public void PizzeriaIntro(Pizzeria pizzeria)
        {
            Console.Clear();
            Console.WriteLine("Welcome to " + pizzeria.PizzeriaName);
            Console.WriteLine(pizzeria.PizzeriaAddress.GetAddress());
            Console.WriteLine("- Our Menu ---------------------------------------------------");
            pizzeria.Menu.DisplayMenu();
            Context.SetState(new OrderingState(Context));
        }

        public void OrderDetails(Pizzeria pizzeria)
        {
            throw new Exception("Cannot accept order. Order has not started yet.");
        }

        public void OrderPaymentDetails(Pizzeria pizzeria)
        {
            throw new Exception("Cannot pay order. Order has not started yet.");
        }

        public void PrepareOrder(Pizzeria pizzeria)
        {
            throw new Exception("Cannot start preparation. Order has not been accepted yet.");
        }

        public void OrderReady()
        {
            throw new Exception("Cannot finish preparation. Order has not been accepted yet.");
        }
    }
}
