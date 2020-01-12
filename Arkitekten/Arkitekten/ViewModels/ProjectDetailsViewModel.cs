using Arkitekten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arkitekten.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<OrderedProduct> OrderedProducts { get; set; }
    }
}
