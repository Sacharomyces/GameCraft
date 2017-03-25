namespace GameCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remGenremodel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Genres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
