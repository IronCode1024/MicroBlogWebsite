namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseDB21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tana_UserInfo", "UserRegion", c => c.String(nullable: false));
            AlterColumn("dbo.Tana_UserInfo", "UserAutograph", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tana_UserInfo", "UserAutograph", c => c.String());
            AlterColumn("dbo.Tana_UserInfo", "UserRegion", c => c.String());
        }
    }
}
