using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.domain.entity.cart
{
   public class Achive

    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProudctId { get; set; }
        public int Qunatity { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;



    }
}
