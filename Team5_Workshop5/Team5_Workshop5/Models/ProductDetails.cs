using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team5_Workshop5.Models
{
    public class ProductDetails
    {
        //public int CustomerId { get; set; }

        //public int? PackageId { get; set; }

        public string Description { get; set; }

        [Display(Name = "Product Name")]
        public string ProdName { get; set; }

        [Display(Name = "Supplier")]
        public string SupName { get; set; }

        [Display(Name = "Trip Start Date")]
        [DataType(DataType.Date)]
        public DateTime TripStart { get; set; }

        [Display(Name = "Trip End Date")]
        [DataType(DataType.Date)]
        public DateTime TripEnd { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }
}