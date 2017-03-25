namespace GameCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreFk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Boardgames", "GenreId", c => c.Byte());
            CreateIndex("dbo.Boardgames", "GenreId");
            AddForeignKey("dbo.Boardgames", "GenreId", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boardgames", "GenreId", "dbo.Genres");
            DropIndex("dbo.Boardgames", new[] { "GenreId" });
            DropColumn("dbo.Boardgames", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
