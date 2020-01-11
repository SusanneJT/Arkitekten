﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arkitekten.Models;
using Arkitekten.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arkitekten.Controllers
{
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
                Projects = _projectRepository.GetAllProjectsForThisOwner("Test")
            };

            //The created view is returned to the bread page (Bread.cshtml)
            return View(projectListViewModel);
        }
        public IActionResult Details(int id)
        {

            ProjectDetailsViewModel projectDetailsViewModel = new ProjectDetailsViewModel
            {
                Project = _projectRepository.GetProjectById(id),
                OrderedProducts = _orderedProductRepository.GetOrderedProductsById(id),
                TestString = id.ToString()
            };

            return View(projectDetailsViewModel);
        }
    }
}