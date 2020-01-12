using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Arkitekten.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProjectRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int CreateProject(Project project, string username)
        {
            project.ProjectOwnerUserName = username;
            project.TotalCost = 0;

            _appDbContext.Projects.Add(project);

            _appDbContext.SaveChanges();
            return project.ProjectId;
        }

        public IEnumerable<Project> GetAllProjectsForThisOwner(string projectOwnerUserName)
        {
            return _appDbContext.Projects.Where(p => p.ProjectOwnerUserName == projectOwnerUserName).Include(o => o.OrderedProduct);
        }

        public Project GetProjectById(int projectId)
        {
            return _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == projectId);
        }

        public void UpdateTotalCost(int projectId)
        {
            decimal totalCost = 0;
            var allOrders = _appDbContext.OrderedProducts.Where(p => p.ProjectId == projectId);
            foreach (var order in allOrders)
            {
                totalCost = totalCost += order.Price;
            }

            _appDbContext.Projects.First(p => p.ProjectId == projectId).TotalCost = totalCost;
            _appDbContext.SaveChanges();
        }
    }
}
