namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseDB3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tana_UserInfo", "UserHeadPortrait", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tana_UserInfo", "UserHeadPortrait", c => c.String());
        }
    }
}
