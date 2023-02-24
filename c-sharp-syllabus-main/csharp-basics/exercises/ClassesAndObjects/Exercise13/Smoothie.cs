using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Exercise13
{
    public class Smoothie
    {
        private string[] ingredients;
        private Dictionary<string, double> fruits;

        public Smoothie(string[] ingredients)
        {
            this.ingredients = ingredients;
            this.fruits = new Dictionary<string, double>()
            {
                { "Strawberries", 1.5 }, { "Banana", 0.5 }, { "Mango", 2.5 }, 
                { "Blueberries", 1 }, { "Raspberries", 1 }, { "Apple", 1.75 }, { "Pineapple", 3.5 }
            };
        }

        public string getCost()
        {
            double costs = 0;
            foreach (var fruit in this.ingredients)
            {
                double value = 0;
                if (this.fruits.TryGetValue(fruit, out value)) costs += value;
            }

            return costs.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"));
        }

        public string getPrice()
        {
            double costs = double.Parse(getCost(), NumberStyles.Currency, CultureInfo.CreateSpecificCulture("en-GB"));
            return (costs + 1.5 * costs).ToString("C", CultureInfo.CreateSpecificCulture("en-GB"));
        }

        public string getName()
        {
            Array.Sort(this.ingredients);
            return this.ingredients.Length == 1
                ? $"{string.Join(" ", this.ingredients)} Smoothie"
                : $"{string.Join(" ", this.ingredients.Select(x => x.Replace("berries", "berry")))} Fusion";
        }

        public string Ingredients()
        {
            return string.Join(" ", this.ingredients);
        }
    }
}