namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        MakeDate = c.DateTime(nullable: false),
                        Content = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "OrderId" });
            DropForeignKey("dbo.Comments", "OrderId", "dbo.Orders");
            DropTable("dbo.Comments");
        }
    }
}
