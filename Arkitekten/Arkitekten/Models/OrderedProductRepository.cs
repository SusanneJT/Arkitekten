using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arkitekten.Models
{
    public class OrderedProductRepository : IOrderedProductRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IProjectRepository _projectRepository;

        public OrderedProductRepository(AppDbContext appDbContext, IProjectRepository projectRepository)
        {
            _appDbContext = appDbContext;
            _projectRepository = projectRepository;
        }

        public void CreateOrderedProduct(OrderedProduct orderedProduct, int projectId)
        {
            orderedProduct.OrderPlaced = DateTime.Now;
            orderedProduct.ProjectId = projectId;
            
            _appDbContext.OrderedProducts.Add(orderedProduct);
            _appDbContext.SaveChanges();

            _projectRepository.UpdateTotalCost(projectId);
        }

        public void ChangeOrderedProduct(string amount, decimal price, int orderedProductId)
        {

            _appDbContext.OrderedProducts.FirstOrDefault(o => o.OrderedProductId == orderedProductId).Amount =  amount;
            _appDbContext.OrderedProducts.FirstOrDefault(o => o.OrderedProductId == orderedProductId).Price = price;

            _appDbContext.SaveChanges();
            _projectRepository.UpdateTotalCost(_appDbContext.OrderedProducts.FirstOrDefault(o => o.OrderedProductId == orderedProductId).ProjectId);
        }

        public IEnumerable<OrderedProduct> GetOrderedProductsByProjectId(int projectId)
        {
            return _appDbContext.OrderedProducts.Where(p => p.ProjectId == projectId);
        }

        public OrderedProduct GetOrderedProductWithId(int orderedProductId)
        {
            return _appDbContext.OrderedProducts.FirstOrDefault(o => o.OrderedProductId == orderedProductId);
        }
    }
}
