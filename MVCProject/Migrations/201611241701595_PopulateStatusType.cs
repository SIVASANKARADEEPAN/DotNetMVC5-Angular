namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStatusType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Status (StatusType) VALUES ('New')");
            Sql("INSERT INTO Status (StatusType) VALUES ('In Progress')");
            Sql("INSERT INTO Status (StatusType) VALUES ('Pending')");
            Sql("INSERT INTO Status (StatusType) VALUES ('Done')");
        }        
        public override void Down()
        {
        }
    }
}
