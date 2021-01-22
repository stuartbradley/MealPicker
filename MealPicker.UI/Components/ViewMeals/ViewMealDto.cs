using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPicker.UI.Components.ViewMeals
{
    public class ViewMealDto
    {
        public Guid MealId { get; set; }
        public string MealName { get; set; }
        public List<ViewMealIngredients> Ingredients { get; set; }
    }

    public class ViewMealIngredients
    {
        public Guid IngredientId { get; set; }
        public string IngredientName { get; set; }
    }
}
