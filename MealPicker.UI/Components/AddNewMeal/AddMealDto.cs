namespace MealPicker.UI.Components.AddNewMeal
{
    public class AddMealDto
    {
        public AddMealDto(string meal, string[] ingredients)
        {
            MealName = meal;
            Ingredients = ingredients;
        }

        public string MealName { get; }
        public string[] Ingredients { get; }
    }
}
