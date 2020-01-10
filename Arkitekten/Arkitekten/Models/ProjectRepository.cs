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
        public IEnumerable<Project> GetAllProjectsForThisOwner(string projectOwnerUserName)
        {
            return _appDbContext.Projects.Where(p => p.ProjectOwnerUserName == projectOwnerUserName).Include(o => o.OrderedProduct);
        }

        public Project GetProjectById(int projectId)
        {
            return _appDbContext.Projects.Include(o => o.OrderedProduct).FirstOrDefault(p => p.ProjectId == projectId);
        }
    }
}
