using OONV.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class Manager
    {
        public IChefBuilder Chef { get; private set; }

        public Manager(IChefBuilder chef) 
        {
            Chef = chef;
        }

        public void ChangeChef(IChefBuilder newChef) 
        {
            Chef = newChef;
        }

        public List<Pizza> PrepareOrder(Order order) 
        {
            int index = 0;
            List<Pizza> foodPrepared = new List<Pizza>();
            foreach (var item in order.Food)
            {
                index += 1;
                order.Notify($"Preparing pizza No. {index} - { item }");
                if (item == "Margarita")
                {
                    foodPrepared.Add(this.Margarita());
                }
                else if (item == "Diavola")
                {
                    foodPrepared.Add(this.Diavola());
                }
                else if (item == "Hawai") 
                {
                    foodPrepared.Add(this.Hawai());
                }
            }
            return foodPrepared;
        }

        private Pizza Diavola()
        {
            Chef.SetMealName("Diavola");
            Chef.MakeDough();
            Chef.MakeBase("Tomato");
            Chef.AddIngredient("Cheese");
            Chef.AddIngredient("Peperony");
            Chef.Bake(10);
            return Chef.GetPizza();
        }

        private Pizza Hawai()
        {
            Chef.SetMealName("Hawai");
            Chef.MakeDough();
            Chef.MakeBase("Tomato");
            Chef.AddIngredient("Cheese");
            Chef.AddIngredient("Ham");
            Chef.AddIngredient("Pineapple");
            Chef.Bake(10);
            return Chef.GetPizza();
        }

        private Pizza Margarita()
        {
            Chef.SetMealName("Margarita");
            Chef.MakeDough();
            Chef.MakeBase("Tomato");
            Chef.AddIngredient("Cheese");
            Chef.Bake(10);
            return Chef.GetPizza();
        }
    }
}
