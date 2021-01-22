using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPicker.Domain.Core;

namespace MealPicker.Domain
{
    public class Meal:Entity
    {
        public string Name { get; private set; }
        private List<Ingredient> _ingredients;
        public IReadOnlyList<Ingredient> Ingredients => _ingredients;

        private Meal(){}
        public Meal(string name, List<string> ingredients):base()
        {
            _ingredients = new List<Ingredient>();
            ingredients.ForEach(i => _ingredients.Add(new Ingredient(i)));
            Name = name;
        }
    }
}
