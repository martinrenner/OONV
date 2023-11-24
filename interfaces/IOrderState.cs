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
        void SetContext(Order context);
        void PizzeriaIntro(Pizzeria pizzeria);
        void OrderDetails(Pizzeria pizzeria);
        void OrderPaymentDetails(Pizzeria pizzeria);
        void PrepareOrder(Pizzeria pizzeria);
        void OrderReady();
    }
}
