namespace GameCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES (1,'Familijna')");
            Sql("INSERT INTO Genres VALUES (2,'Strategiczna')");
            Sql("INSERT INTO Genres VALUES (3,'Logiczna')");
            Sql("INSERT INTO Genres VALUES (4,'Karciana')");
            Sql("INSERT INTO Genres VALUES (5,'Imprezowa')");
            Sql("INSERT INTO Genres VALUES (6,'Ekonomiczna')");

        }

        public override void Down()
        {
        }
    }
}
