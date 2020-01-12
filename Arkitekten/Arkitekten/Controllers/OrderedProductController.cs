using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arkitekten.Models;
using Arkitekten.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arkitekten.Controllers
{
    [Authorize]
    public class OrderedProductController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IOrderedProductRepository _orderedProductRepository;

        public OrderedProductController(IProjectRepository projectRepository, IOrderedProductRepository orderedProductRepository)
        {
            _projectRepository = projectRepository;
            _orderedProductRepository = orderedProductRepository;

        }
        // GET: /<controller>/
        public ActionResult AddOrderedProduct(int id)
        {
            ViewBag.ProjectId = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddOrderedProduct(OrderedProduct orderedProduct, int id)
        {
            if (ModelState.IsValid)
            {
                _orderedProductRepository.CreateOrderedProduct(orderedProduct, id);
                return RedirectToAction("Details", "Project", new { id });
            }
            //return RedirectToAction("AddOrderedProduct", new { id });
            ViewBag.ProjectId = id;
            return View(orderedProduct);
        }

        public ActionResult ChangeOrderedProduct(int id)
        {
            ChangeOrderViewModel changeOrderViewModel = new ChangeOrderViewModel
            {
                OrderedProduct = _orderedProductRepository.GetOrderedProductWithId(id)
            };
            
            return View(changeOrderViewModel);
        }

        [HttpPost]
        public IActionResult ChangeOrderedProduct(string amount, decimal price, int id)
        {
            if (ModelState.IsValid)
            {
                _orderedProductRepository.ChangeOrderedProduct(amount, price, id);
                var projectId = _orderedProductRepository.GetOrderedProductWithId(id).ProjectId;
                return RedirectToAction("Details", "Project", new { id = projectId });
            }

            return RedirectToAction("ChangeOrderedProduct", new { id});
        }
    }
}
