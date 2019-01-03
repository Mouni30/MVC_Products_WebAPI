using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_Products_WebAPI.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("constr")
        {

        }
        public DbSet<ProductModel> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().ToTable("tbl_products");
            modelBuilder.Entity<ProductModel>().HasKey(p => p.ProductID);
            modelBuilder.Entity<ProductModel>().Property(p => p.ProductName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<ProductModel>().Property(p => p.ProductPrice).IsRequired();
            modelBuilder.Entity<ProductModel>().Property(p => p.ProductCategory).IsRequired().HasMaxLength(100);
        }
    }
}