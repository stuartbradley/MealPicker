using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPicker.Application.Commands.AddNewMealCommand
{
    public class AddMealDto
    {
        public string MealName { get; set; }
        public string[] Ingredients { get; set; }
    }
}
