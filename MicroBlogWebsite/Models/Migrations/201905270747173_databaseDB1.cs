namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tana_GoodFriend", "UserInfo_Id", "dbo.Tana_UserInfo");
            DropForeignKey("dbo.Tana_GoodFriend", "UserInfos_Id", "dbo.Tana_UserInfo");
            DropForeignKey("dbo.Tana_GoodFriend", "UserInfoss_Id", "dbo.Tana_UserInfo");
            DropForeignKey("dbo.Tana_MicroBlog", "UserInfo_Id", "dbo.Tana_UserInfo");
            DropIndex("dbo.Tana_GoodFriend", new[] { "UserInfo_Id" });
            DropIndex("dbo.Tana_GoodFriend", new[] { "UserInfos_Id" });
            DropIndex("dbo.Tana_GoodFriend", new[] { "UserInfoss_Id" });
            DropIndex("dbo.Tana_MicroBlog", new[] { "UserInfo_Id" });
            DropColumn("dbo.Tana_GoodFriend", "UserInfo_Id");
            DropColumn("dbo.Tana_GoodFriend", "UserInfos_Id");
            DropColumn("dbo.Tana_GoodFriend", "UserInfoss_Id");
            DropColumn("dbo.Tana_MicroBlog", "UserInfo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tana_MicroBlog", "UserInfo_Id", c => c.Int());
            AddColumn("dbo.Tana_GoodFriend", "UserInfoss_Id", c => c.Int());
            AddColumn("dbo.Tana_GoodFriend", "UserInfos_Id", c => c.Int());
            AddColumn("dbo.Tana_GoodFriend", "UserInfo_Id", c => c.Int());
            CreateIndex("dbo.Tana_MicroBlog", "UserInfo_Id");
            CreateIndex("dbo.Tana_GoodFriend", "UserInfoss_Id");
            CreateIndex("dbo.Tana_GoodFriend", "UserInfos_Id");
            CreateIndex("dbo.Tana_GoodFriend", "UserInfo_Id");
            AddForeignKey("dbo.Tana_MicroBlog", "UserInfo_Id", "dbo.Tana_UserInfo", "Id");
            AddForeignKey("dbo.Tana_GoodFriend", "UserInfoss_Id", "dbo.Tana_UserInfo", "Id");
            AddForeignKey("dbo.Tana_GoodFriend", "UserInfos_Id", "dbo.Tana_UserInfo", "Id");
            AddForeignKey("dbo.Tana_GoodFriend", "UserInfo_Id", "dbo.Tana_UserInfo", "Id");
        }
    }
}
