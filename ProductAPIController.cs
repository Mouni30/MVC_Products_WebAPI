using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_Products_WebAPI.Models;

namespace MVC_Products_WebAPI.Controllers
{
    public class ProductAPIController : ApiController
    {
        MyDBContext db = new MyDBContext();
        // GET: api/ProductAPI
        public IEnumerable<ProductModel> Get()
        {
            return db.Products.ToList();
        }

        // GET: api/ProductAPI/5
        public ProductModel Get(int id)
        {
            return db.Products.FirstOrDefault(o => o.ProductID == id);
        }

        // POST: api/ProductAPI
        public bool Post([FromBody]ProductModel value)
        {
            db.Products.Add(value);
            db.SaveChanges();
            return true;
        }

        // PUT: api/ProductAPI/5
        public void Put(int id, [FromBody]ProductModel value)
        {
            var dbmodel = db.Products.FirstOrDefault(o => o.ProductID == id);
            dbmodel.ProductName = value.ProductName;
            dbmodel.ProductPrice = value.ProductPrice;
            dbmodel.ProductCategory = value.ProductCategory;
            db.SaveChanges();
        }

        // DELETE: api/ProductAPI/5
        public void Delete(int id)
        {
            var model = (from o in db.Products where o.ProductID == id select o).FirstOrDefault();
            db.Products.Remove(model);
            db.SaveChanges();
        }
        [Route("api/ProductAPI/Search/{key}")]
        [HttpGet]
        public IEnumerable<ProductModel> Search(string key)
        {
            var model = db.Products.Where(o => o.ProductName.Contains(key) || o.ProductCategory.Contains(key)).ToList();
            return model;
        }
    }
}
