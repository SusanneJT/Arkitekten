using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arkitekten.Models
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjectsForThisOwner(string projectOwnerUserName);
        Project GetProjectById(int projectId);
    }
}
