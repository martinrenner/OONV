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
        private Order Context { get; set; }

        public OrderPreparationState(Order context) {
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
            throw new Exception("Cannot pay order again. It's already in preparation.");
        }

        public void PrepareOrder(Pizzeria pizzeria)
        {
            Context.Notify("Your order is now being prepared");
            pizzeria.Manager.PrepareOrder(Context);
            Context.SetState(new OrderPreparedState(Context));
        }

        public void OrderReady()
        {
            throw new Exception("Order preparation finished.");
        }
    }
}
