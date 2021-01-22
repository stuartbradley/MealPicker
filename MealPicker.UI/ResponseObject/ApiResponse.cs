using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPicker.UI.ResponseObject
{
    public class ApiResponse<T>
    {
        public string Version { get; set; }
        public int StatusCode{ get; set; }
        public string Message{ get; set; }
        public bool IsError{ get; set; }
        public T Result { get; set; }
    }
}
