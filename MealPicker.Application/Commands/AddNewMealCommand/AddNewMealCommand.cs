using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MealPicker.Application.Commands.AddNewMealCommand
{
    public class AddNewMealCommand:IRequest<Guid>
    {
        public string Name { get; }
        public string[] Ingredients { get; }

        public AddNewMealCommand(string name, string[] ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
    }
}
