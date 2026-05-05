using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.dto.product
{
    public class updateproducts:productbase
    {
        [Required]
        public Guid Id { get; set; }

    }

}
