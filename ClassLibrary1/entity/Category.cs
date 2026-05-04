using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.domain.entity
{
 public class Catogry
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Proudct>? proudcts { get; set; }

    }
}
