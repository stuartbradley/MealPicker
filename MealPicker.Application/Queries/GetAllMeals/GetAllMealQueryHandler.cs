using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MealPicker.Application.Utils;
using MediatR;
using Microsoft.Data.SqlClient;

namespace MealPicker.Application.Queries.GetAllMeals
{
    public class GetAllMealQueryHandler:IRequestHandler<GetAllMealsQuery, List<GetMealDto>>
    {
        private readonly ConnectionString _connection;

        public GetAllMealQueryHandler(ConnectionString connection)
        {
            _connection = connection;
        }
        public async Task<List<GetMealDto>> Handle(GetAllMealsQuery request, CancellationToken cancellationToken)
        {
            string sql = @"SELECT m.id as MealId, m.name as MealName, i.Id as IngredientId, i.Name as IngredientName FROM MEALS m INNER JOIN ingredients i ON i.mealid = m.id";

            using SqlConnection connection = new SqlConnection(_connection.Value);
            var mealDic = new Dictionary<Guid,GetMealDto>();
            var meals = await connection.QueryAsync<GetMealDto, IngredientGetDto, GetMealDto>(sql,
                (meal, ingredient) =>
                {
                    if (!mealDic.TryGetValue(meal.MealId, out var currentMeal))
                    {
                        currentMeal = meal;
                        mealDic.Add(currentMeal.MealId, meal);
                    }

                    currentMeal.Ingredients.Add(ingredient);
                    return currentMeal;
                },splitOn:"MealId, IngredientId");
            return meals.Distinct().ToList();
        }
    }
}
