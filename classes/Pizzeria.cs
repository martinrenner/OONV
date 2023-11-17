using OONV.interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class Pizzeria
    {
        public string PizzeriaName { get; set; }
        public Address PizzeriaAddress { get; set; }
        private List<Order> PizzeriaOrders { get; set; }
        public Menu Menu { get; set; }
        public Manager Manager { get; set; }
        public IChefBuilder Chef { get; set; }

        public Pizzeria(string name, Address address, IChefBuilder chef) 
        {
            PizzeriaName = name;
            PizzeriaAddress = address;
            PizzeriaOrders = new List<Order>();
            Menu = new Menu();
            Chef = chef;
            Manager = new Manager(Chef);
            InitializeMenu();
        }
        public void Run()
        {
            while (true) 
            {
                Order order = new Order();
                User user = new User();
                order.Attach(user);
                order.PizzeriaIntro(this);
                order.OrderDetails(this);
                order.OrderPaymentDetails(this);
                order.PrepareOrder(this);
                order.OrderReady();
                PizzeriaOrders.Add(order);
            }
        }

        public void ChangeChef(IChefBuilder chef)
        {
            Chef = chef;
            Manager.ChangeChef(chef);
        }

        private void InitializeMenu()
        {
            Menu.AddMenuItem(new MenuItem("Margarita", 8.99));
            Menu.AddMenuItem(new MenuItem("Diavola", 11.99));
            Menu.AddMenuItem(new MenuItem("Hawai", 13.99));
        }
    }
}
