using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arkitekten.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectOwnerUserName { get; set; }
        public string ProjectName { get; set; }  
        public List<OrderedProduct> OrderedProduct { get; set; }
        public decimal TotalCost { get; set; }
    }
}
