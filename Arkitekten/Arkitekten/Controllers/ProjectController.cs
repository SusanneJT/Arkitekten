using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arkitekten.Models;
using Arkitekten.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arkitekten.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IOrderedProductRepository _orderedProductRepository;

        public ProjectController(IProjectRepository projectRepository, IOrderedProductRepository orderedProductRepository)
        {
            _projectRepository = projectRepository;
            _orderedProductRepository = orderedProductRepository;
            
        }
        // GET: /<controller>/
        public ViewResult List()
        {
            ProjectListViewModel projectListViewModel = new ProjectListViewModel
            {
                Projects = _projectRepository.GetAllProjectsForThisOwner(User.Identity.Name)
            };

            //The created view is returned to the bread page (Bread.cshtml)
            return View(projectListViewModel);
        }
        public ActionResult Details(int id)
        {

            ProjectDetailsViewModel projectDetailsViewModel = new ProjectDetailsViewModel
            {
                Project = _projectRepository.GetProjectById(id),
                OrderedProducts = _orderedProductRepository.GetOrderedProductsById(id),
                TestString = id.ToString()
            };

            return View(projectDetailsViewModel);
        }

        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                int projectId = _projectRepository.CreateProject(project, User.Identity.Name);
                return RedirectToAction("Details", new { id = projectId });
            }
            return View(project);
        }
    }
}
