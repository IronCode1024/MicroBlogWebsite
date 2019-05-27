namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tana_Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentatorUserID = c.String(),
                        BeCommentatorUserID = c.String(),
                        Content_text = c.String(),
                        Content_img = c.String(),
                        Content_video = c.String(),
                        Content_sound = c.String(),
                        CommentTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tana_GoodFriend",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FollowUserID = c.Int(nullable: false),
                        FansUserID = c.Int(nullable: false),
                        Establish = c.String(),
                        FriendRemarks = c.String(),
                        AitemeUserID = c.Int(nullable: false),
                        UserInfo_Id = c.Int(),
                        UserInfos_Id = c.Int(),
                        UserInfoss_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tana_UserInfo", t => t.UserInfo_Id)
                .ForeignKey("dbo.Tana_UserInfo", t => t.UserInfos_Id)
                .ForeignKey("dbo.Tana_UserInfo", t => t.UserInfoss_Id)
                .Index(t => t.UserInfo_Id)
                .Index(t => t.UserInfos_Id)
                .Index(t => t.UserInfoss_Id);
            
            CreateTable(
                "dbo.Tana_UserInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsetName = c.String(),
                        UserEmail = c.String(),
                        UserPassword = c.String(),
                        UserBirthday = c.DateTime(nullable: false),
                        UserRegion = c.String(),
                        UserHeadPortrait = c.String(),
                        UserAutograph = c.String(),
                        States = c.Boolean(nullable: false),
                        RegisterTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tana_Grouping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        FriendUserID = c.Int(nullable: false),
                        MyUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tana_MicroBlog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Title = c.String(),
                        Content_text = c.String(),
                        Content_img = c.String(),
                        Content_video = c.String(),
                        Content_sound = c.String(),
                        Points_number = c.Int(nullable: false),
                        Place = c.Boolean(nullable: false),
                        Cansee_states = c.Int(nullable: false),
                        ReleaseTime = c.DateTime(nullable: false),
                        UserInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tana_UserInfo", t => t.UserInfo_Id)
                .Index(t => t.UserInfo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tana_MicroBlog", "UserInfo_Id", "dbo.Tana_UserInfo");
            DropForeignKey("dbo.Tana_GoodFriend", "UserInfoss_Id", "dbo.Tana_UserInfo");
            DropForeignKey("dbo.Tana_GoodFriend", "UserInfos_Id", "dbo.Tana_UserInfo");
            DropForeignKey("dbo.Tana_GoodFriend", "UserInfo_Id", "dbo.Tana_UserInfo");
            DropIndex("dbo.Tana_MicroBlog", new[] { "UserInfo_Id" });
            DropIndex("dbo.Tana_GoodFriend", new[] { "UserInfoss_Id" });
            DropIndex("dbo.Tana_GoodFriend", new[] { "UserInfos_Id" });
            DropIndex("dbo.Tana_GoodFriend", new[] { "UserInfo_Id" });
            DropTable("dbo.Tana_MicroBlog");
            DropTable("dbo.Tana_Grouping");
            DropTable("dbo.Tana_UserInfo");
            DropTable("dbo.Tana_GoodFriend");
            DropTable("dbo.Tana_Comment");
        }
    }
}
