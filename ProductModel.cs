using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Products_WebAPI.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductCategory { get; set; }
    }
}