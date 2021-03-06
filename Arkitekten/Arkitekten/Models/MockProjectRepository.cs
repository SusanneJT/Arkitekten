﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arkitekten.Models
{
    public class MockProjectRepository : IProjectRepository
    {
        public IEnumerable<Project> Projects =>
            new List<Project>
            {
                new Project {ProjectId = 1, ProjectOwnerUserName = "Bettan", TotalCost = 4500, ProjectName = "Anderssons villa"},
                new Project {ProjectId = 2, ProjectOwnerUserName = "Bettan", TotalCost = 9800, ProjectName = "Pruttfirmans kontor"},
                new Project {ProjectId = 3, ProjectOwnerUserName = "Lasse", TotalCost = 19500, ProjectName = "Von Gyllenstiernas badrum"}
            };

        public int CreateProject(Project project, string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAllProjectsForThisOwner(string projectOwnerUserName)
        {
            return Projects.Where(p => p.ProjectOwnerUserName == projectOwnerUserName);
        }

        public Project GetProjectById(int projectId)
        {
            return Projects.FirstOrDefault(p => p.ProjectId == projectId);
        }

        public void UpdateTotalCost(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
