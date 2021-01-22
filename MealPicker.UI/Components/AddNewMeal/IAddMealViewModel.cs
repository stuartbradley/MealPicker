using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MealPicker.UI.ResponseObject;

namespace MealPicker.UI.Components.AddNewMeal
{
    public interface IAddMealViewModel
    {
        [Required]
        string MealName { get; set; }
        [Required]
        string Ingredients { get; set; }
        string Message { get; }
        Task<ApiResponse<Guid>> SaveMeal();
    }
}