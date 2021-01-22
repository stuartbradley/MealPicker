using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealPicker.UI.Components.ViewMeals
{
    public interface IViewMealViewModel
    {
        List<ViewMealDto> Meals { get; set; }
        string Message { get; set; }
        Task PopulateMeals();
    }
}