using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.dto.Identity
{
   public class CreateUser:BaseModel
    {
        public required string FullName { get; set; }

        public required string ConfirmPassowerd { get; set; }

    }

}
