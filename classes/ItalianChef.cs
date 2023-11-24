using OONV.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class ItalianChef : IChefBuilder
    {
        public Pizza Pizza { get; private set; }
        
        public ItalianChef() {
            Pizza = new Pizza();
        }

        public void SetMealName(string name)
        {
            Pizza.SetPizzaName(name);
        }

        public void MakeDough()
        {
            Pizza.MakeDough();
        }

        public void MakeBase(string pizza_base)
        {
            Pizza.MakeBase(pizza_base);
        }

        public void AddIngredient(string ingredient)
        {
            Pizza.AddIngredient(ingredient);
        }

        public void Bake(int time_in_seconds)
        {
            Pizza.Bake(time_in_seconds);
        }

        public Pizza GetPizza()
        {
            Pizza hotova = Pizza;
            Pizza = new Pizza();
            return hotova;
        }
    }
}
