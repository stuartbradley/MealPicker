using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPicker.Domain.Core;

namespace MealPicker.Domain
{
    public class Ingredient:Entity
    {
        public string Name { get; private set; }

        private Ingredient(){}
        public Ingredient(string name):base()
        {
            Name = name;
        }
    }
}
