using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arkitekten.Models
{
    public interface IOrderedProductRepository
    {
        void CreateOrderedProduct(OrderedProduct orderedProduct, int projectId);
        void ChangeOrderedProduct(OrderedProduct orderedProduct);
        public IEnumerable<OrderedProduct> GetOrderedProductsById(int projectId);

    }
}
