using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Exercise13
{
    public class Smoothie
    {
        private string[] _ingredients;
        private Dictionary<string, double> _fruits;

        public Smoothie(string[] ingredients)
        {
            _ingredients = ingredients;
            _fruits = new Dictionary<string, double>()
            {
                { "Strawberries", 1.5 }, { "Banana", 0.5 }, { "Mango", 2.5 }, 
                { "Blueberries", 1 }, { "Raspberries", 1 }, { "Apple", 1.75 }, { "Pineapple", 3.5 }
            };
        }

        public string GetCost()
        {
            double costs = 0;
            foreach (var fruit in this._ingredients)
            {
                double value = 0;
                if (_fruits.TryGetValue(fruit, out value))
                {
                    costs += value;
                }
            }

            return costs.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"));
        }

        public string GetPrice()
        {
            double costs = double.Parse(GetCost(), NumberStyles.Currency, CultureInfo.CreateSpecificCulture("en-GB"));
            return (costs + 1.5 * costs).ToString("C", CultureInfo.CreateSpecificCulture("en-GB"));
        }

        public string GetName()
        {
            Array.Sort(this._ingredients);
            return this._ingredients.Length == 1
                ? $"{string.Join(" ", _ingredients)} Smoothie"
                : $"{string.Join(" ", _ingredients.Select(x => x.Replace("berries", "berry")))} Fusion";
        }

        public string Ingredients()
        {
            return string.Join(" ", this._ingredients);
        }
    }
}