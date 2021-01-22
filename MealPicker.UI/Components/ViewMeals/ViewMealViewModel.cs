using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MealPicker.UI.Objects;
using MealPicker.UI.ResponseObject;

namespace MealPicker.UI.Components.ViewMeals
{
    public class ViewMealViewModel : IViewMealViewModel
    {
        private readonly HttpClient _client;
        public List<ViewMealDto> Meals { get; set; }
        public string Message { get; set; }

        public ViewMealViewModel(HttpClient client)
        {
            _client = client;
        }

        public async Task PopulateMeals()
        {
            var response = await _client.GetFromJsonAsync<ApiResponse<List<ViewMealDto>>>("Meals");
            if (response.IsError)
                Message = response.Message;
            else
                Meals = response.Result;
        }
    }
}
