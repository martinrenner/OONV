using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class Menu
    {
        private List<MenuItem> Items { get; set; }

        public Menu()
        {
            Items = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem item)
        {
            Items.Add(item);
        }

        public void DisplayMenu()
        {
            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Name} - {item.Price:C}");
            }
        }

        public MenuItem GetMenuItemByName(string name)
        {
            return Items.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
