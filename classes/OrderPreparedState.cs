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
        private Order Context { get; set; }

        public OrderPreparedState(Order context) {
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
            throw new Exception("Cannot accept the order. It's already prepared.");
        }

        public void OrderPaymentDetails(Pizzeria pizzeria)
        {
            throw new Exception("Cannot pay order again. It's already prepared.");
        }

        public void PrepareOrder(Pizzeria pizzeria)
        {
            throw new Exception("Cannot start preparation. Order is already prepared.");
        }

        public void OrderReady()
        {
            Context.Notify("Your order is ready");
            Console.Write("Waiting for pickup...");
            Console.ReadLine();
        }
    }
}
