using OONV.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.interfaces
{
    interface IChefBuilder
    {
        public void SetMealName(string name);
        public void MakeDough();
        public void MakeBase(string pizza_base);
        public void AddIngredient(string ingredient);
        public void Bake(int time_in_seconds);
        public Pizza GetPizza();
    }
}
