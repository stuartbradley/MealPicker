using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MealPicker.UI.Components.AddNewMeal;
using MealPicker.UI.Components.ViewMeals;

namespace MealPicker.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");
            builder.Services.AddDevExpressBlazor();
    
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44320/api/") });

            builder.Services.AddTransient<IAddMealViewModel, AddMealViewModel>();
            builder.Services.AddScoped<IViewMealViewModel, ViewMealViewModel>();

            await builder.Build().RunAsync();
        }
    }
}
