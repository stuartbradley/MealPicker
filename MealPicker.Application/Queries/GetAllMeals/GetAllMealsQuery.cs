using System.Collections.Generic;
using MediatR;

namespace MealPicker.Application.Queries.GetAllMeals
{
    public class GetAllMealsQuery:IRequest<List<GetMealDto>>
    {
        
    }
}
