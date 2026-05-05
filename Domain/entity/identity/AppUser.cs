using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.domain.entity.identity
{
  public class AppUser:IdentityUser
    {
        public string fullname { get; set; } = string.Empty;
    }
}
