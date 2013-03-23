namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_014 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderFlavors",
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderFlavors", new[] { "FlavorId" });
            DropIndex("dbo.OrderFlavors", new[] { "OrderId" });
            DropForeignKey("dbo.OrderFlavors", "FlavorId", "dbo.Flavors");
            DropForeignKey("dbo.OrderFlavors", "OrderId", "dbo.Orders");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderFlavors");
        }
    }
}
