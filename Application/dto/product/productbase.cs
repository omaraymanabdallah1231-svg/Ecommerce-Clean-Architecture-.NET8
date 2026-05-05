using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.dto.product
{
   public class productbase
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Describition { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal price { get; set; }
        [Required]
        public int qualty { get; set; }
        [Required]
        public Guid CatogryId { get; set; }

    }
}
