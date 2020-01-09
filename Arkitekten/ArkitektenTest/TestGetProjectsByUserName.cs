using Arkitekten.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ArkitektenTest
{
    public class TestGetProjectsByUserName
    {
        //This test ensures that the method GetAllProjectsForThisOwner works
        //..and returnes the expected amount of projects for that owner.

        [Fact]
        public void TestsTheMethodGetAllProjectsForThisOwner()
        {
            //Arrange
            IProjectRepository projectRepository = new MockProjectRepository();

            //Act
            IEnumerable<Project> mockProjects = projectRepository.GetAllProjectsForThisOwner("Bettan");
            int countProjects = 0;
            foreach (var project in mockProjects)
            {
                countProjects++;
            }

            //Assert
            Assert.Equal(2, countProjects);
        }
    }
}
