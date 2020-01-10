using Arkitekten.Controllers;
using Arkitekten.Models;
using Arkitekten.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace ArkitektenTest
{
    public class TestProjectDetailsView
    {
        [Fact]
        public void TestsTheViewForProjectDetails()
        {
            //Arrange
            IProjectRepository projectRepository = new MockProjectRepository();
            IOrderedProductRepository orderedProductRepository = new MockOrderedProductRepository();
            var controller = new ProjectController(projectRepository, orderedProductRepository);

            // Act 
            var result = controller.Details(2);

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
