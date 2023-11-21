using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class Pizza
    {
        public string Name { get; private set; }
        public string? PizzaDough { get; private set; }
        public string? PizzaBase { get; private set; }
        public bool IsBaked { get; private set; }
        public List<string> PizzaIngredients { get; private set; }

        public Pizza(string name)
        {
            Name = name;
            PizzaIngredients = new List<string>();
        }

        public void MakeDough()
        {
        }

        public void MakeBase(string pizzaBase)
        {
            if (string.IsNullOrEmpty(pizzaBase))
                throw new ArgumentException("Pizza base cannot be null or empty.");

            PizzaBase = pizzaBase;
        }

        public void AddIngredient(string ingredient)
        {
            if (string.IsNullOrEmpty(ingredient))
                throw new ArgumentException("Ingredient cannot be null or empty.");

            PizzaIngredients.Add(ingredient);
        }

        public void Bake(int bakingTimeInSeconds)
        {
            Thread.Sleep(bakingTimeInSeconds * 1000);
            IsBaked = true;
        }

        public string IsReady()
        {
            if (IsBaked == false)
                return "Pizza is not baked. Please contact manager.";
            else
                return "Pizza is ready!";
        }
    }
}
