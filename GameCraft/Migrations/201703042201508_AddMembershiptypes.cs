namespace GameCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershiptypes : DbMigration
    {
        public override void Up()

        {
            Sql("UPDATE MembershipTypes SET Name='Brak' WHERE Id=1"); 
            Sql("UPDATE MembershipTypes SET Name='Miesiêczny' WHERE Id=2"); 
            Sql("UPDATE MembershipTypes SET Name='Kwartalny' WHERE Id=3"); 
            Sql("UPDATE MembershipTypes SET Name='Roczny' WHERE Id=4"); 
           
        }
        
        public override void Down()
        {
        }
    }
}
