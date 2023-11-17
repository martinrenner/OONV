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
            List<Pizza> foodPrepared = new List<Pizza>();
            foreach (var item in order.Food)
            {
                if (item == "Margarita")
                {
                    Chef.Margarita();
                    foodPrepared.Add(Chef.GetPizza());
                }
                else if (item == "Diavola")
                {
                    Chef.Diavola();
                    foodPrepared.Add(Chef.GetPizza());
                }
                else if (item == "Hawai") 
                {
                    Chef.Hawai();
                    foodPrepared.Add(Chef.GetPizza());
                }
            }
            return foodPrepared;
        }
    }
}
