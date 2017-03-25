namespace GameCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGenreIdToNotNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boardgames", "GenreId", "dbo.Genres");
            DropIndex("dbo.Boardgames", new[] { "GenreId" });
            AlterColumn("dbo.Boardgames", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Boardgames", "GenreId");
            AddForeignKey("dbo.Boardgames", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boardgames", "GenreId", "dbo.Genres");
            DropIndex("dbo.Boardgames", new[] { "GenreId" });
            AlterColumn("dbo.Boardgames", "GenreId", c => c.Byte());
            CreateIndex("dbo.Boardgames", "GenreId");
            AddForeignKey("dbo.Boardgames", "GenreId", "dbo.Genres", "Id");
        }
    }
}
