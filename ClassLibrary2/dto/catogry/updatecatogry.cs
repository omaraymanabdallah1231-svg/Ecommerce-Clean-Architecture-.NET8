using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.dto.catogry
{
 public   class updatecatogry:catogrybase
    {
        [Required]
        public Guid Id { get; set; }


    }
}
