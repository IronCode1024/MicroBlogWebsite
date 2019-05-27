namespace Models.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.UserInfoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.UserInfoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.UserInfo.AddOrUpdate<UserInfo>(
                new UserInfo { Id = 1, UserName = "ÍÐÄá", UserEmail = "1453190098@qq.com", UserPassword = "123", UserBirthday = Convert.ToDateTime("1999/1/1"), UserRegion = "ºþ±±Îäºº", UserHeadPortrait = "Images/1.jpg", UserAutograph = "I am IronMan", States = false, RegisterTime = DateTime.Now },
                new UserInfo { Id = 2, UserName = "ÍÐÄá2", UserEmail = "1453@qq.com", UserPassword = "123", UserBirthday = Convert.ToDateTime("1998/1/1"), UserRegion = "Õã½­º¼ÖÝ", UserHeadPortrait = "Images/2.jpg", UserAutograph = "I am IronMan2", States = false, RegisterTime = DateTime.Now }
                );

            context.GoodFriend.AddOrUpdate<GoodFriend>(
                new GoodFriend { Id = 101, UserID = 1, FollowUserID = 2, FansUserID = 0, Establish =DateTime.Now,FriendRemarks="0",AitemeUserID=0 }
                );
        }
    }
}
