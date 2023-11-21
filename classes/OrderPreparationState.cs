using OONV.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class OrderPreparationState : IOrderState
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
            throw new Exception("Cannot pay order again. It's already in preparation.");
        }

        public void PrepareOrder(Order context, Pizzeria pizzeria)
        {
            context.Notify("Your order is now being prepared");
            pizzeria.Manager.PrepareOrder(context);
            context.CurrentState = new OrderPreparedState();
        }

        public void OrderReady(Order context)
        {
            throw new Exception("Order preparation finished.");
        }
    }
}
