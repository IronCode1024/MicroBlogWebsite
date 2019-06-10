namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tana_UserInfo", "UserFansNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tana_UserInfo", "UserFansNum");
        }
    }
}
