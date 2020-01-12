using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arkitekten.Models
{
    public interface IOrderedProductRepository
    {
        void CreateOrderedProduct(OrderedProduct orderedProduct, int projectId);
        void ChangeOrderedProduct(String amount, decimal price, int orderedProductId);
        public IEnumerable<OrderedProduct> GetOrderedProductsByProjectId(int projectId);
        public OrderedProduct GetOrderedProductWithId(int orderedProductId);

    }
}
