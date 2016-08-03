using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsTopSeller { get; set; }

        public string PriceDescription
        {
            get { return this.Price.ToString("C"); }
        }
    }
}