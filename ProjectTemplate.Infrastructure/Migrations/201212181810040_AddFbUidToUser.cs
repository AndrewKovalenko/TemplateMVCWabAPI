namespace ProjectTemplate.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFbUidToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FacebookUid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "FacebookUid");
        }
    }
}
