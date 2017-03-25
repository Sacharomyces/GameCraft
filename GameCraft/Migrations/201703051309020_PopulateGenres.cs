namespace GameCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES (1,'Familijna')");
            Sql("INSERT INTO Genres VALUES (2,'Strategiczna')");
            Sql("INSERT INTO Genres VALUES (3,'Logiczna')");
            Sql("INSERT INTO Genres VALUES (4,'Ekonimiczna')");
            Sql("INSERT INTO Genres VALUES (5,'Karciana')");
            Sql("INSERT INTO Genres VALUES (6,'Imprezowa')");
        }
        
        public override void Down()
        {
        }
    }
}
