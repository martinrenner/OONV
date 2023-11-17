using OONV.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class User : IOrderObserver
    {
        public User() 
        {
        }

        public void Update(string message)
        {
            Console.WriteLine("Customer message - " + message);
        }
    }
}
