namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusTypeToStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Status", "StatusType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Status", "StatusType");
        }
    }
}
