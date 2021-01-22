using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MealPicker.UI.ResponseObject;

namespace MealPicker.UI.Components.AddNewMeal
{
    public class AddMealViewModel : IAddMealViewModel
    {
        private HttpClient _client;
        [Required]
        public string MealName { get; set; }
        [Required]
        public string Ingredients { get; set; }
        private string[] _ingredient => Ingredients.Split();
        public string Message { get; private set; }

        public AddMealViewModel()
        {
            
        }
        //public AddMealViewModel(HttpClient client)
        //{
        //    _client = client;
        //}

        public async Task<ApiResponse<Guid>> SaveMeal()
        {
            AddMealDto dto = this;
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44320/api/");
            var response = await _client.PostAsJsonAsync("Meals", dto);
            var responseBody = await response.Content.ReadFromJsonAsync<ApiResponse<Guid>>();

            if (responseBody.IsError)
                Message = responseBody.Message;
            return responseBody;

        }



        public static implicit operator AddMealDto(AddMealViewModel model)
        {
            return new AddMealDto(model.MealName, model._ingredient);
        }
}
}
