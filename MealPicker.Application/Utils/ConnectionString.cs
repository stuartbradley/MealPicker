﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPicker.Application.Utils
{
    public class ConnectionString
    {
        public ConnectionString(string value) => Value = value;
        public string Value { get; }
    }
}
