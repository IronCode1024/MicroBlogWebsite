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
                new UserInfo { Id = 101, UserName = "����1", UserEmail = "1453190098@qq.com", UserSex="��", UserPassword = "123456asdfgh", UserBirthday = Convert.ToDateTime("1999/1/1"), UserRegion = "�����人", UserHeadPortrait = "Images/1.jpg", UserAutograph = "I am IronMan1", States = false },
                new UserInfo { Id = 102, UserName = "����2", UserEmail = "1453@qq.com", UserPassword = "123456asdfgh", UserSex = "Ů", UserBirthday = DateTime.Now, UserRegion = "�㽭����", UserHeadPortrait = "Images/2.jpg", UserAutograph = "I am IronMan2", States = false, CreateTime = DateTime.Now },
                new UserInfo { Id = 104, UserName = "����3", UserEmail = "1453dfds@qq.com", UserPassword = "123456asdfgh", UserSex = "��", UserBirthday = Convert.ToDateTime("1998/1/1"), UserRegion = "�����ϲ�", UserHeadPortrait = "Images/3.jpg", UserAutograph = "I am IronMan4" }
                );

            context.GoodFriend.AddOrUpdate<GoodFriend>(
                new GoodFriend { Id = 1, MyUserID = 101, FollowUserID = 102,FansUserID=103, CreateTime = DateTime.Now, FriendRemarks = "", AitemeUserID = null },
                new GoodFriend { Id = 2, MyUserID = 102, FollowUserID = 103,FansUserID=101, CreateTime = DateTime.Now, FriendRemarks = "", AitemeUserID = null },
                new GoodFriend { Id =3, MyUserID = 103, FollowUserID = 101,FansUserID=102, CreateTime = DateTime.Now, FriendRemarks = "", AitemeUserID = null }
                );

            context.Grouping.AddOrUpdate<Grouping>(
                new Grouping { Id=1,GroupName="��һ������",FriendUserID=1,MyUserID=101 }
                );
        }
    }
}
