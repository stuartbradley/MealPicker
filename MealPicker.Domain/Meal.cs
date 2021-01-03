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
        private List<Ingredient> _ingredients;
        public IReadOnlyList<Ingredient> Ingredients => _ingredients;
    }
}
