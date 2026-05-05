using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.application.dto.catogry;
namespace ecommerce.application.dto.product
{
  public  class Getproudct:productbase
    {
        [Required]
        public Guid Id { get; set; }
        public GetCatogry? catogry { get; set; }


    }


}
