namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseDB2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tana_GoodFriend", "Establish", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tana_GoodFriend", "Establish", c => c.String());
        }
    }
}
