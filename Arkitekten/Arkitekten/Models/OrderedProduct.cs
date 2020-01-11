using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arkitekten.Models
{
    public class OrderedProduct
    {
        [BindNever]
        public int OrderedProductId { get; set; }
        public int ProjectId { get; set; }

        [Display(Name = "Produktens namn")]
        [Required(ErrorMessage = "Namn på varan måste anges")]
        public string ProductName { get; set; }

        [Display(Name = "Typ av produkt")]
        public string ProductType { get; set; }

        [Required(ErrorMessage = "Pris på varan måste anges")]
        [Display(Name = "Pris")]
        public decimal Price { get; set; }

        [Display(Name = "Övriga detaljer")]
        public string Details { get; set; }

        //Amount is set to string to be able to specify desired amount, e.g. 10kg or 10pcs
        [Required(ErrorMessage = "Du måste ange beställd mängd")]
        [Display(Name = "Mängd")]
        public string Amount { get; set; }
        public DateTime OrderPlaced { get; set; }

        [Display(Name = "Återförsäljare")]
        [Required(ErrorMessage = "Du måste ange återförsäljare")]
        public string Retailer { get; set; }
    }
}
