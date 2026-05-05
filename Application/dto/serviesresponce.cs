using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.dto
{
    public class serviesresponce
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public serviesresponce(bool success, string message = null!)
        {
            Success = success;
            Message = message;
        }
    }
}
