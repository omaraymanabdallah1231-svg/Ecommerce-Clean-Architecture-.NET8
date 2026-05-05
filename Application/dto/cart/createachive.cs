using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.dto.cart
{
  public class createachive
    {
        [Required]
        public Guid ProudctId { get; set; }
        [Required]

        public int Qunatity { get; set; }
        [Required]

        public Guid UserId { get; set; }
    }
}
