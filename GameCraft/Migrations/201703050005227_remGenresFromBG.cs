namespace GameCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remGenresFromBG : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boardgames", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Boardgames", new[] { "Genre_Id" });
            DropColumn("dbo.Boardgames", "Genre_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Boardgames", "Genre_Id", c => c.Byte());
            CreateIndex("dbo.Boardgames", "Genre_Id");
            AddForeignKey("dbo.Boardgames", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
