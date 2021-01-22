using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using MealPicker.Application.Commands.AddNewMealCommand;
using MealPicker.Application.Queries;
using MealPicker.Application.Queries.GetAllMeals;
using MediatR;

namespace MealPicker.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public MealsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ApiResponse> AddMeal(AddMealDto dto)
        {
            AddNewMealCommand command = new AddNewMealCommand(dto.MealName, dto.Ingredients);
            var result = await _mediatr.Send(command);
            return new ApiResponse("Meal Added Successfully", result, statusCode:201); 
        }

        [HttpGet]
        public async Task<ApiResponse> GetAllMeals()
        {
            GetAllMealsQuery query = new GetAllMealsQuery();
            var result = await _mediatr.Send(query);
            return new ApiResponse("Successfully Returned All Meals", result);
        }
    }
}
