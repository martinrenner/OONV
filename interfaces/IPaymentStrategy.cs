using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.interfaces
{
    interface IPaymentStrategy
    {
        public bool ProcessPayment(double amount);
    }
}
