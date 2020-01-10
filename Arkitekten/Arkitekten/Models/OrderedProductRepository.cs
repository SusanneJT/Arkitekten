using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arkitekten.Models
{
    public class OrderedProductRepository : IOrderedProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderedProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void ChangeOrderedProduct(OrderedProduct orderedProduct)
        {
            throw new NotImplementedException();
        }

        public void CreateOrderedProduct(OrderedProduct orderedProduct)
        {
            orderedProduct.OrderPlaced = DateTime.Now;

            _appDbContext.OrderedProducts.Add(orderedProduct);

            _appDbContext.SaveChanges();
        }
        public IEnumerable<OrderedProduct> GetOrderedProductsById(int projectId)
        {
            return _appDbContext.OrderedProducts.Where(p => p.ProjectId == projectId);
        }
    }
}
