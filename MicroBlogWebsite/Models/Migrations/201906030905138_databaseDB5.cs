namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseDB5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tana_UserInfo", "UserBirthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tana_UserInfo", "UserBirthday", c => c.DateTime(nullable: false));
        }
    }
}
