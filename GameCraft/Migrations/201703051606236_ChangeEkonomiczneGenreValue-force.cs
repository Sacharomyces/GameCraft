namespace GameCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEkonomiczneGenreValueforce : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Genres SET Name='Ekonomiczne' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
