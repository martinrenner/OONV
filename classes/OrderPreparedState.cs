using OONV.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class OrderPreparedState : IOrderState
    {
        public void PizzeriaIntro(Order context, Pizzeria pizzeria)
        {
            Console.WriteLine("Cannot start new order when old is unfinished.");
        }

        public void OrderDetails(Order context, Pizzeria pizzeria)
        {
            Console.WriteLine("Cannot accept the order. It's already prepared.");
        }

        public void OrderPaymentDetails(Order context, Pizzeria pizzeria)
        {
            Console.WriteLine("Cannot pay order again. It's already prepared.");
        }

        public void PrepareOrder(Order context, Pizzeria pizzeria)
        {
            Console.WriteLine("Cannot start preparation. Order is already prepared.");
        }

        public void OrderReady(Order context)
        {
            context.Notify("Your order is ready");
            Console.Write("Waiting for pickup...");
            Console.ReadLine();
        }
    }
}
