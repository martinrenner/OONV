using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string ZIP { get; private set; }

        public Address(string street, string city, string country, string zip)
        {
            Street = street;
            City = city;
            Country = country;
            ZIP = zip;
        }

        public string GetAddress() 
        { 
            return Street + ", " + City + ", " + Country + ", " + ZIP; 
        }
    }
}
