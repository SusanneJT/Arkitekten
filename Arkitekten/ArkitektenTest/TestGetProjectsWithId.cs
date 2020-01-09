using Arkitekten.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ArkitektenTest
{
    public class TestGetProjectsWithId
    {
        //This test ensures that the method GetProjectById works and returns the right project
        [Fact]
        public void TestsTheMethodGetProjectById()
        {
            //Arrange
            IProjectRepository projectRepository = new MockProjectRepository();

            //Act
            Project mockProject = projectRepository.GetProjectById(3);

            //Assert
            Assert.Equal(19500, mockProject.TotalCost);
        }
    }
}
