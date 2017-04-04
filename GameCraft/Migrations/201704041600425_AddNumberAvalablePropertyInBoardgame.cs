namespace GameCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvalablePropertyInBoardgame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boardgames", "NumberAvailable", c => c.Byte(nullable: false));

            Sql("UPDATE Boardgames SET NumberAvailable = InStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Boardgames", "NumberAvailable");
        }
    }
}
