using ecommerce.application.dto.product;
using System.Collections.ObjectModel;

namespace ecommerce.application.dto.catogry
{
    public class GetCatogry:catogrybase
    {
        public Guid Id { get; set; }

        public ICollection<Getproudct>? proudcts { get; set; }
    }
}