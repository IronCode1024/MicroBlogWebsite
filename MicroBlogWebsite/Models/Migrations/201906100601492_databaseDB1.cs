namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseDB1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tana_Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentatorUserID = c.Int(),
                        BeCommentatorUserID = c.Int(),
                        Content_text = c.String(),
                        Content_img = c.String(),
                        Content_video = c.String(),
                        Content_sound = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tana_GoodFriend",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyUserID = c.Int(nullable: false),
                        FollowUserID = c.Int(),
                        FansUserID = c.Int(),
                        FriendRemarks = c.String(nullable: false, maxLength: 50),
                        AitemeUserID = c.Int(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tana_UserInfo", t => t.FansUserID)
                .ForeignKey("dbo.Tana_UserInfo", t => t.FollowUserID)
                .ForeignKey("dbo.Tana_UserInfo", t => t.MyUserID)
                .Index(t => t.MyUserID)
                .Index(t => t.FollowUserID)
                .Index(t => t.FansUserID);
            
            CreateTable(
                "dbo.Tana_UserInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        UserEmail = c.String(nullable: false, maxLength: 150),
                        UserPassword = c.String(nullable: false, maxLength: 16),
                        UserSex = c.String(maxLength: 4),
                        UserBirthday = c.DateTime(),
                        UserReadPortrait = c.String(),
                        UserAegion = c.String(),
                        UserHutograph = c.String(),
                        States = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
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
                        Place = c.String(),
                        Cansee_states = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        MicroBlogUserID_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tana_UserInfo", t => t.MicroBlogUserID_Id)
                .Index(t => t.MicroBlogUserID_Id);
            
            CreateTable(
                "dbo.Tana_Grouping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        FriendUserID = c.Int(),
                        MyUserID = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tana_MicroBlog", "MicroBlogUserID_Id", "dbo.Tana_UserInfo");
            DropForeignKey("dbo.Tana_GoodFriend", "MyUserID", "dbo.Tana_UserInfo");
            DropForeignKey("dbo.Tana_GoodFriend", "FollowUserID", "dbo.Tana_UserInfo");
            DropForeignKey("dbo.Tana_GoodFriend", "FansUserID", "dbo.Tana_UserInfo");
            DropIndex("dbo.Tana_MicroBlog", new[] { "MicroBlogUserID_Id" });
            DropIndex("dbo.Tana_GoodFriend", new[] { "FansUserID" });
            DropIndex("dbo.Tana_GoodFriend", new[] { "FollowUserID" });
            DropIndex("dbo.Tana_GoodFriend", new[] { "MyUserID" });
            DropTable("dbo.Tana_Grouping");
            DropTable("dbo.Tana_MicroBlog");
            DropTable("dbo.Tana_UserInfo");
            DropTable("dbo.Tana_GoodFriend");
            DropTable("dbo.Tana_Comment");
        }
    }
}
