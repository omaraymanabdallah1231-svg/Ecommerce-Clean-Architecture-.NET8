using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.dto.Identity
{
  public  class BaseModel
    {
        public required string Email { get; set; }
        public required string Passowerd { get; set; }

    }
}
