using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.interfaces
{
    interface IOrderObserver
    {
        void Update(string message);
    }
}
