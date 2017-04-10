namespace GameCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRentalsAndNumberAvailable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Boardgame_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boardgames", t => t.Boardgame_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Boardgame_Id)
                .Index(t => t.Customer_Id);
            
            AddColumn("dbo.Boardgames", "NumberAvailable", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Boardgame_Id", "dbo.Boardgames");
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropIndex("dbo.Rentals", new[] { "Boardgame_Id" });
            DropColumn("dbo.Boardgames", "NumberAvailable");
            DropTable("dbo.Rentals");
        }
    }
}
