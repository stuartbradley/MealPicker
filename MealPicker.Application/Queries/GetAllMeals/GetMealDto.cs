using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPicker.Domain;

namespace MealPicker.Application.Queries.GetAllMeals
{
    public class GetMealDto
    {
        public Guid MealId { get; }
        public string MealName { get; }
        public List<IngredientGetDto> Ingredients { get; set; } = new List<IngredientGetDto>();

    }

    public class IngredientGetDto
    {
        public Guid IngredientId { get; }
        public string IngredientName { get; }

    }
}
