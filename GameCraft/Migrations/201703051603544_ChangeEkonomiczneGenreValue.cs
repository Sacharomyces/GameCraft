namespace GameCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEkonomiczneGenreValue : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Genres SET Name='Ekonokiczne' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
