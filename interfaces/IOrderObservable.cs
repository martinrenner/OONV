using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.interfaces
{
    interface IOrderObservable
    {
        void Attach(IOrderObserver observer);
        void Detach(IOrderObserver observer);
        void Notify(string message);
    }
}
