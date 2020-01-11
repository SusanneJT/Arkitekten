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

        public void ChangeOrderedProduct(OrderedProduct orderedProduct)
        {
            throw new NotImplementedException();
        }

        public void CreateOrderedProduct(OrderedProduct orderedProduct, int projectId)
        {
            orderedProduct.OrderPlaced = DateTime.Now;
            orderedProduct.ProjectId = projectId;
            
            
            _appDbContext.OrderedProducts.Add(orderedProduct);

            _appDbContext.SaveChanges();
            _projectRepository.UpdateTotalCost(projectId);
        }
        public IEnumerable<OrderedProduct> GetOrderedProductsById(int projectId)
        {
            return _appDbContext.OrderedProducts.Where(p => p.ProjectId == projectId);
        }
    }
}
