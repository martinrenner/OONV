using OONV.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizzeria pizzeria = new Pizzeria("Pizzeria Don Giovanni", new Address("Piazza del Colosseo", "Rome", "Italia", "00184"), new ItalianChef());
            pizzeria.Run();
        }
    }
}
