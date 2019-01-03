namespace MVC_Products_WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        ProductPrice = c.Int(nullable: false),
                        ProductCategory = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_products");
        }
    }
}
