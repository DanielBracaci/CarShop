namespace CarShopWpf3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Make = c.String(),
                        Year = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Power = c.Double(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "ClientId", "dbo.Clients");
            DropIndex("dbo.Cars", new[] { "ClientId" });
            DropTable("dbo.Clients");
            DropTable("dbo.Cars");
        }
    }
}
