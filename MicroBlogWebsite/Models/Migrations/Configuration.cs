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
                new UserInfo { Id = 1, UserName = "����1", UserEmail = "1453190098@qq.com", UserPassword = "123456", UserFansNum = 1, UserBirthday = Convert.ToDateTime("1999/11/17"), UserRegion = "�����人", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/1.jpg", UserAutograph = "I am IronMan1", States = false },
                new UserInfo { Id = 2, UserName = "����2", UserEmail = "dfhgfdgfdg@qq.com", UserPassword = "123456sdfg", UserFansNum = 2, UserBirthday = Convert.ToDateTime("1995/03/17"), UserRegion = "�㽭����", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/2.jpg", UserAutograph = "I am IronMan2", States = false },
                new UserInfo { Id = 3, UserName = "����3", UserEmail = "gdfgdfg@qq.com", UserPassword = "dfgdfsffd", UserBirthday = Convert.ToDateTime("1999/1/1"), UserRegion = "�����ϲ�", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/3.jpg", UserAutograph = "I am IronMan3", States = false },
                new UserInfo { Id = 4, UserName = "����4", UserEmail = "gfdgdf@qq.com", UserPassword = "dfgdfgdfgdf", UserBirthday = Convert.ToDateTime("2002/1/1"), UserRegion = "�㶫����", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/4.jpg", UserAutograph = "I am IronMan4", States = false },
                new UserInfo { Id = 5, UserName = "����5", UserEmail = "gfdgfg@qq.com", UserPassword = "123456", UserBirthday = Convert.ToDateTime("1998/10/15"), UserRegion = "�㶫����", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/5.jpg", UserAutograph = "I am IronMan5", States = false },
                new UserInfo { Id = 6, UserName = "����6", UserEmail = "gfdg@qq.com", UserPassword = "4532455324", UserBirthday = Convert.ToDateTime("1999/1/10"), UserRegion = "����֣��", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/6.jpg", UserAutograph = "I am IronMan4", States = false },
                new UserInfo { Id = 7, UserName = "����7", UserEmail = "gfdg@qq.com", UserPassword = "3453453453", UserBirthday = Convert.ToDateTime("1999/10/1"), UserRegion = "���ϳ�ɳ", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/7.jpg", UserAutograph = "I am IronMan7", States = false },
                new UserInfo { Id = 8, UserName = "����8", UserEmail = "gfdgfgdfg@qq.com", UserPassword = "1234343343456", UserBirthday = Convert.ToDateTime("1999/11/10"), UserRegion = "�ӱ�ʯ��ׯ", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/8.jpg", UserAutograph = "I am IronMan8", States = false },
                new UserInfo { Id = 9, UserName = "����9", UserEmail = "gfdg@qq.com", UserPassword = "435434535", UserBirthday = Convert.ToDateTime("1997/06/12"), UserRegion = "ɽ������", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/9.jpg", UserAutograph = "I am IronMan9", States = false },
                new UserInfo { Id = 10, UserName = "����10", UserEmail = "fddgtrg@qq.com", UserPassword = "534536534", UserBirthday = Convert.ToDateTime("1999/1/1"), UserRegion = "�����Ͼ�", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/10.jpg", UserAutograph = "I am IronMan10" }

                );

            context.GoodFriend.AddOrUpdate<GoodFriend>(
                new GoodFriend { Id = 1, MyUserID = 1, FollowUserID = 2, CreateTime = DateTime.Now, FriendRemarks = "", AitemeUserID = null },
                new GoodFriend { Id = 2, MyUserID = 1, FansUserID = 2, CreateTime = DateTime.Now, FriendRemarks = "", AitemeUserID = null },
                new GoodFriend { Id = 3, MyUserID = 2, FollowUserID = 1, CreateTime = DateTime.Now, FriendRemarks = "", AitemeUserID = null },
                new GoodFriend { Id = 4, MyUserID = 2, FansUserID = 1, CreateTime = DateTime.Now, FriendRemarks = "", AitemeUserID = null }
                );

            context.MicroBlog.AddOrUpdate<MicroBlog>(
            new MicroBlog { Id = 1, UserID = 1, Title = "1�ҵĵ�һ��΢��", Content_text = "�ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢���ҵĵ�һ��̤��΢��", Cansee_states = 0 },
            new MicroBlog { Id = 2, UserID = 2, Title = "2�ҵĵ�һ��΢��", Content_text = "", Content_img = "/Content/images/UserImg/UserMicroBlogImg/1.jpg", Cansee_states = 0 },
            new MicroBlog { Id = 3, UserID = 3, Title = "3�ҵĵ�һ��΢��", Content_text = "����������һ����ʰ�쵵����磬����������ﲻ�����������ķ羰������һ������ͬ��Ҳ���Ų�ͬ���ԡ���ͬ���ʡ���ͬ�˸��������ˡ���������������;�У������ʶ�������ܶ���ˣ���ͬ�����������Ų�ͬ��Ʒ�ʼ����������͡�ϲ���Ͱ�������������Ѱ��յĳ߶ȡ� ", Cansee_states = 0 },
            new MicroBlog { Id = 4, UserID = 4, Title = "4�ҵĵ�һ��΢��", Content_text = "˵������ڵĳԣ��Ͳ��ò��ἰǧ����������ڵı�־��ʳ����ӡ������ӣ���ʷ�ϼ������ڴ���֮ǰ���ѳ��֣�������Ҷ����Ŵ�����ƶ��ɣ�����ǹ��������������Ⱥ����飬�����˽������Ӳ��𽥳�ΪѰ�����ռҶ���ڲ����ϵ�ʳ�", Cansee_states = 0 },
            new MicroBlog { Id = 5, UserID = 5, Title = "5�ҵĵ�һ��΢��", Content_text = "����������ʮ���ˣ�����ÿ�춼�����ʽ�������˲��������ת˲���ŵ���������ÿһ��˲�䣬���Ƕ�Ҫ��ϧ���˺�ãã��������֮���ܹ�������֪�������మ���Ǳ�Ȼ����żȻ��ڤڤ֮�У�����һ�ֽ���Ե�ֵ�˵������ʶ������ô�࣬��ͷ��Ҳ����ֻ����ôһ�������߽������ǵ��ġ� ���ǣ���Щ�˱�����ϸ�ĺǻ����������������ͷΣ���Ϊ����֪������Щ����ֵ�ñ�������ϧһ���ӵġ�", Cansee_states = 0 },
            new MicroBlog { Id = 6, UserID = 6, Title = "6�ҵĵ�һ��΢��", Content_text = "ʱ�����ۣ������ɿ�����ţ����Ǵ���СС��Ӥ�����������ô��һ���ˣ�������̷·�ֻ��һת�ۼ�����顣 ������̣���ʱ�򲻽���̾����������ô�����õ��£������ֺαؿ��Χ����һЩ��ֵ��������ϧ������� ����һ�㣬����һ�㣬Ҫ����ʱ���վ���ĥȥһ�С� ʮ��ǰ���ǿ��ܻ�˵���������Һ�������һ�����໥��飬�粢��һ�����������ĵ�·������������Ȼ��ʮ��󣬷羰���ɣ������˷ǣ������ǻ���Ҫ������ǰ�ߡ� ��Ե���Ѿ���Ҳ�����ǻ������ǵ�����������һ˿�ۼ������վ�ֻ���������������еĴҴҹ��͡�", Cansee_states = 0 },
            new MicroBlog { Id = 7, UserID = 7, Title = "7�ҵĵ�һ��΢��", Content_text = "�� ʧ��ʱ���������Ϊ���ǲ����ᣬ��ù��ɹ�ʱ�õ�����������Ϊ���ǹ��ơ� ��������Զ����������ģ������Ǽ�������������˶��壬��ͷһ�����Ż�Ȼ��������ʧȥ�ıȵõ��Ļ�Ҫ�ࡣ���ʣ�������������Ӧ����û�д𰸵ġ� �ƺ�һ�ж�����ô��������Ȼ��Ҫ�õ���Ҫ�Ķ������ͱ�������һЩ��������ͬ���ǣ���ǰ���ɹ���·�ϣ����ǻᾭ��һЩ������꣬����ĥ���뿼�飬����ն����һ��ֱǰ����ͷ��ͣЪ�������ǵ�������Ŀ�꣬Ȼ��ֵ�����Ǹж����ǣ��������Ĺ����У�Ҳ�����ǻ�������ôһ�����ˣ�����û�ж�ô�Ժյ���ݻ��λ����������һ���������ϵ��ģ����ǲ����ں������ݣ������ں��������е�ֻ���������飬������Ĺ����������ǳ�˵�������������޹����£�����������������͸��������ϧ�����顣 �����е����Ѳ������������ѣ������������Ķ�������õı��𣬾�����ϧ�� ���ǵ����������ı䲻��ʲô�������������Ǵ���һ˿�������������绹�����õģ���������ңԶ��·;�У��յ�վ���ǳɹ����ͺñ�����������˸�Ĺ�â���Ѿ���������������ǵ�������·�����������ǵĶ���������ϣ����", Cansee_states = 0 },
            new MicroBlog { Id = 8, UserID = 8, Title = "8�ҵĵ�һ��΢��", Content_text = "�� �����Ǹ��ܴ����Ķ������ͺ�����ĭһ����һ�����ƣ��ֻ���������֮���ǲ㱡����Ĥ��һ˺���顣 ����·��������û��˭һ��������˭�ߵ������������⣬���ǲ�֪���ĸ�������һ��ʼ�ܶ�����ǣ����ǰ�ߣ�һ��С��Ū��һ�����ٲ�С����Ū��һ����Ȼ���������ţ���С��ȫ����ɢ�ˣ����ֻʣ����Ȼһ�� �ߴ���ʤ�����������˿���վ�������Ķ��壬�������˿���������ͨ�����������ܵ�һ�У����ѵ����ǲ��¶�����į���ѵ�����û��Ϊ��λ����������ʲô������ֻ��վ����ߴ������ǲ������ף������Ƕ�ô�ĸ��ӣ������Ƕ�ô�Ĵ��������ǹۿ���������֮��Ĺ��Ķ��ǣ�������������ף�Ť������˼�����������һ���ܾ��ˣ����ȴʲôҲû�еõ���������������������������ǰ���е�һ�ж����Բ�ֵһ�ᣬ��һ��һ����Ⱦ�������ѱ��ǧ���ٿף����ǲ��ѡ� �������ʱ����Щӵ�и�Ȩְ���ˣ��ſ�ʼ��ʶ�������Ǻ���ʧȥ������������Ҫ��һ�������� ���� �� ���ǿ�ʼ��ڣ���ڵ���Ϊʲôû�кú���ϧ��Щ�����ĶԴ����ǵ��ˡ��������ʵ������У����ǲ�С�Ķ�ʧ���Լ����ģ����ǻ����������׵����¡�����ĸ��飬Ȼ�����ڵ�����ʲôҲ�ı䲻�ˣ�ҲӦ�����Ǿ仰����������Ҫ�ȵ�ʧȥ�˲�ѧ����ϧ����", Cansee_states = 0 },
            new MicroBlog { Id = 9, UserID = 9, Title = "9�ҵĵ�һ��΢��", Content_text = "�������Ƕ���һЩ����˵��ֻ��һ��Ƭ�Σ���һЩ�˻��¶�������˵�������һ�β���������������зַ����룬������Ҫ�ģ���Ҫ������ϧ�� ����·�кܶ�Ĳ�ڣ�ÿ���˶�Ҫ����ͬ��ѡ����Щѡ�������û�������ĺ��뻵���Ի�����������ʲô�����ҲҪ�����Լ�����Ϊ�����Լ���һ�޶���һ������������ʹ��һ�仰����������ϧ����Ҫ�����޵Ĺ����˷������޵ĺ���С�", Cansee_states = 0 },
            new MicroBlog { Id = 10, UserID = 10, Title = "10�ҵĵ�һ��΢��", Content_text = "ѧ����ݣ�ѧ�ᵭȻ����Ȼʱ����Ǩ����ȥ���֣���ǵ�Ҳ�ã����������������һЦ��ֻ�Ǹ�л�����߹�����Щ�������¡���������Ц����ӭ�������������ߣ�����ȻĿ�ͣ���ֿף����������ν�ľ������������۵�����������Ҫί����ȫ����������£��ұ�ŵĿ���", Cansee_states = 0 }
            );
        }
    }
}
