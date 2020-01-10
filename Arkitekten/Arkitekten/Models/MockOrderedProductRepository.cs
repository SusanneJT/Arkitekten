using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arkitekten.Models
{
    public class MockOrderedProductRepository : IOrderedProductRepository
    {
        public IEnumerable<OrderedProduct> OrderedProducts =>
            new List<OrderedProduct>
            {
                new OrderedProduct {OrderedProductId = 1, ProjectId = 1, ProductName = "Blomtapet", Amount = "12 rullar", Price = 6400, ProductType = "Tapet", Retailer = "Karlssons tapeter", Details = "Till sovrummet på andra plan", OrderPlaced = DateTime.Now},
                new OrderedProduct {OrderedProductId = 2, ProjectId = 1, ProductName = "Parkettgolv", Amount = "120 kvm", Price = 58000, ProductType = "Golv", Retailer = "Anitas golv", Details = "Till hela övre plan", OrderPlaced = DateTime.Now},
                new OrderedProduct {OrderedProductId = 3, ProjectId = 2, ProductName = "Marmorgolv", Amount = "20 kvm", Price = 8000, ProductType = "Golv", Retailer = "Roffes", Details = "Entrén", OrderPlaced = DateTime.Now},
                new OrderedProduct {OrderedProductId = 4, ProjectId = 3, ProductName = "Marmorgolv", Amount = "20 kvm", Price = 8000, ProductType = "Golv", Retailer = "Roffes", Details = "Entrén", OrderPlaced = DateTime.Now},
                new OrderedProduct {OrderedProductId = 5, ProjectId = 3, ProductName = "Heltäckningsmatta", Amount = "20 kvm", Price = 8000, ProductType = "Golv", Retailer = "Roffes", Details = "Entrén", OrderPlaced = DateTime.Now}
            };
        public void ChangeOrderedProduct(OrderedProduct orderedProduct)
        {
            throw new NotImplementedException();
        }

        public void CreateOrderedProduct(OrderedProduct orderedProduct)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderedProduct> GetOrderedProductsById(int projectId) 
        {
            return OrderedProducts.Where(p => p.ProjectId == projectId);
        }
    }
}
