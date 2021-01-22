using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPicker.Domain.Core;

namespace MealPicker.Domain
{
    public class Pot:Entity
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
    }
}
