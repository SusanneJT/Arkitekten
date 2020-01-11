using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arkitekten.Models
{
    public class Project
    {
        [BindNever]
        public int ProjectId { get; set; }
        public string ProjectOwnerUserName { get; set; }

        [Required(ErrorMessage = "Ange namn på projektet")]
        [Display(Name = "Projektets namn")]
        [StringLength(50)]
        public string ProjectName { get; set; }  
        public List<OrderedProduct> OrderedProduct { get; set; }
        public decimal TotalCost { get; set; }
    }
}
