using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.domain.entity.cart
{
 public class payment
    {
        [Key]
        public  Guid Id { get; set; }
        public  string Name { get; set; }
    }
}
