namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_017 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coffees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 100),
                        Name = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flavors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        CoffeeId = c.Int(nullable: false),
                        TastingNotes = c.String(maxLength: 200),
                        EngoyWith = c.String(maxLength: 200),
                        Description = c.String(maxLength: 1000),
                        Roast = c.String(maxLength: 100),
                        Region = c.String(maxLength: 100),
                        Price = c.Double(nullable: false),
                        CoffeeImage = c.Binary(),
                        ContentType = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coffees", t => t.CoffeeId, cascadeDelete: true)
                .Index(t => t.CoffeeId);
            
            CreateTable(
                "dbo.CurrentOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        FlavorId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Flavors", t => t.FlavorId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.FlavorId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCheckout = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CurrentOrders", new[] { "FlavorId" });
            DropIndex("dbo.CurrentOrders", new[] { "OrderId" });
            DropIndex("dbo.Flavors", new[] { "CoffeeId" });
            DropForeignKey("dbo.CurrentOrders", "FlavorId", "dbo.Flavors");
            DropForeignKey("dbo.CurrentOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Flavors", "CoffeeId", "dbo.Coffees");
            DropTable("dbo.Orders");
            DropTable("dbo.CurrentOrders");
            DropTable("dbo.Flavors");
            DropTable("dbo.Coffees");
        }
    }
}
