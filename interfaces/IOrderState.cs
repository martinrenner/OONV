using OONV.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.interfaces
{
    interface IOrderState
    {
        void PizzeriaIntro(Order context, Pizzeria pizzeria);
        void OrderDetails(Order context, Pizzeria pizzeria);
        void OrderPaymentDetails(Order context, Pizzeria pizzeria);
        void PrepareOrder(Order context, Pizzeria pizzeria);
        void OrderReady(Order context);
    }
}
