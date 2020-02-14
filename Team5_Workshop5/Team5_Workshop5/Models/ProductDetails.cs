using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team5_Workshop5.Models
{
    public class Customer
    {
        public int PackageId { get; set; }

        public string Description { get; set; }

        public string ProdName { get; set; }

        public string SupName { get; set; }

        public DateTime TripStart { get; set; }

        public DateTime TripEnd { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }
    }
}