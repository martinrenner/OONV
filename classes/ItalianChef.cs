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
        public Pizza? Pizza { get; private set; }
        public void Diavola()
        {
            Pizza = new Pizza("Diavola");
            Pizza.MakeDough();
            Pizza.MakeBase("Tomato");
            Pizza.AddIngredient("Cheese");
            Pizza.AddIngredient("Peperony");
            Pizza.Bake(10);
        }

        public void Hawai()
        {
            Pizza = new Pizza("Hawai");
            Pizza.MakeDough();
            Pizza.MakeBase("Tomato");
            Pizza.AddIngredient("Cheese");
            Pizza.AddIngredient("Ham");
            Pizza.AddIngredient("Pineapple");
            Pizza.Bake(10);
        }

        public void Margarita()
        {
            Pizza = new Pizza("Margarita");
            Pizza.MakeDough();
            Pizza.MakeBase("Tomato");
            Pizza.AddIngredient("Cheese");
            Pizza.Bake(10);
        }

        public Pizza GetPizza()
        {
            return Pizza ?? throw new InvalidOperationException("Pizza not created yet.");
        }
    }
}
