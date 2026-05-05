using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.dto
{
    public record LoginResponce
    (
        bool success=false,
        string message=null!,
        string RefreshToken=null!,
        string Token=null!

        );

}
