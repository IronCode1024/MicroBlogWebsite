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
                new UserInfo { Id = 1, UserName = "托尼1", UserEmail = "1453190098@qq.com", UserPassword = "123456", UserFansNum = 1, UserBirthday = Convert.ToDateTime("1999/11/17"), UserRegion = "湖北武汉", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/1.jpg", UserAutograph = "I am IronMan1", States = false },
                new UserInfo { Id = 2, UserName = "托尼2", UserEmail = "dfhgfdgfdg@qq.com", UserPassword = "123456sdfg", UserFansNum = 2, UserBirthday = Convert.ToDateTime("1995/03/17"), UserRegion = "浙江杭州", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/2.jpg", UserAutograph = "I am IronMan2", States = false },
                new UserInfo { Id = 3, UserName = "托尼3", UserEmail = "gdfgdfg@qq.com", UserPassword = "dfgdfsffd", UserBirthday = Convert.ToDateTime("1999/1/1"), UserRegion = "江西南昌", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/3.jpg", UserAutograph = "I am IronMan3", States = false },
                new UserInfo { Id = 4, UserName = "托尼4", UserEmail = "gfdgdf@qq.com", UserPassword = "dfgdfgdfgdf", UserBirthday = Convert.ToDateTime("2002/1/1"), UserRegion = "广东广州", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/4.jpg", UserAutograph = "I am IronMan4", States = false },
                new UserInfo { Id = 5, UserName = "托尼5", UserEmail = "gfdgfg@qq.com", UserPassword = "123456", UserBirthday = Convert.ToDateTime("1998/10/15"), UserRegion = "广东深圳", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/5.jpg", UserAutograph = "I am IronMan5", States = false },
                new UserInfo { Id = 6, UserName = "托尼6", UserEmail = "gfdg@qq.com", UserPassword = "4532455324", UserBirthday = Convert.ToDateTime("1999/1/10"), UserRegion = "河南郑州", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/6.jpg", UserAutograph = "I am IronMan4", States = false },
                new UserInfo { Id = 7, UserName = "托尼7", UserEmail = "gfdg@qq.com", UserPassword = "3453453453", UserBirthday = Convert.ToDateTime("1999/10/1"), UserRegion = "湖南长沙", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/7.jpg", UserAutograph = "I am IronMan7", States = false },
                new UserInfo { Id = 8, UserName = "托尼8", UserEmail = "gfdgfgdfg@qq.com", UserPassword = "1234343343456", UserBirthday = Convert.ToDateTime("1999/11/10"), UserRegion = "河北石家庄", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/8.jpg", UserAutograph = "I am IronMan8", States = false },
                new UserInfo { Id = 9, UserName = "托尼9", UserEmail = "gfdg@qq.com", UserPassword = "435434535", UserBirthday = Convert.ToDateTime("1997/06/12"), UserRegion = "山东济南", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/9.jpg", UserAutograph = "I am IronMan9", States = false },
                new UserInfo { Id = 10, UserName = "托尼10", UserEmail = "fddgtrg@qq.com", UserPassword = "534536534", UserBirthday = Convert.ToDateTime("1999/1/1"), UserRegion = "江苏南京", UserHeadPortrait = "/Content/images/UserImg/HeadPortrait/10.jpg", UserAutograph = "I am IronMan10" }

                );

            context.GoodFriend.AddOrUpdate<GoodFriend>(
                new GoodFriend { Id = 1, MyUserID = 1, FollowUserID = 2, CreateTime = DateTime.Now, FriendRemarks = "", AitemeUserID = null },
                new GoodFriend { Id = 2, MyUserID = 1, FansUserID = 2, CreateTime = DateTime.Now, FriendRemarks = "", AitemeUserID = null },
                new GoodFriend { Id = 3, MyUserID = 2, FollowUserID = 1, CreateTime = DateTime.Now, FriendRemarks = "", AitemeUserID = null },
                new GoodFriend { Id = 4, MyUserID = 2, FansUserID = 1, CreateTime = DateTime.Now, FriendRemarks = "", AitemeUserID = null }
                );

            context.MicroBlog.AddOrUpdate<MicroBlog>(
            new MicroBlog { Id = 1, UserID = 1, Title = "1我的第一个微博", Content_text = "我的第一个踏浪微博我的第一个踏浪微博我的第一个踏浪微博我的第一个踏浪微博我的第一个踏浪微博我的第一个踏浪微博我的第一个踏浪微博我的第一个踏浪微博我的第一个踏浪微博我的第一个踏浪微博我的第一个踏浪微博我的第一个踏浪微博我的第一个踏浪微博我的第一个踏浪微博", Cansee_states = 0 },
            new MicroBlog { Id = 2, UserID = 2, Title = "2我的第一个微博", Content_text = "", Content_img = "/Content/images/UserImg/UserMicroBlogImg/1.jpg", Cansee_states = 0 },
            new MicroBlog { Id = 3, UserID = 3, Title = "3我的第一个微博", Content_text = "我们生活在一个五彩斑斓的世界，在这个世界里不光有着美丽的风景，爱是一种欣赏同样也有着不同个性、不同气质、不同人格魅力的人。在漫漫的人生旅途中，你会相识、相遇很多的人，不同的人身上有着不同的品质及魅力，欣赏、喜欢和爱便成了我们最难把握的尺度。 ", Cansee_states = 0 },
            new MicroBlog { Id = 4, UserID = 4, Title = "4我的第一个微博", Content_text = "说到端午节的吃，就不得不提及千百年来端午节的标志性食物“粽子”。粽子，据史料记载早在春秋之前就已出现，是由粽叶包裹糯米蒸制而成，最初是古人用来祭祀祖先和神灵，而到了晋代粽子才逐渐成为寻常百姓家端午节餐桌上的食物。", Cansee_states = 0 },
            new MicroBlog { Id = 5, UserID = 5, Title = "5我的第一个微博", Content_text = "地球上有六十亿人，我们每天都在与各式各样的人擦肩而过。转瞬即逝的相逢与离别，每一个瞬间，我们都要珍惜。人海茫茫，人与人之间能够相遇相知或相亲相爱，是必然还是偶然？冥冥之中，自有一种叫作缘分的说法。认识的人那么多，到头来也不过只有那么一两个人走进了我们的心。 于是，这些人被我们细心呵护，真诚相待，掏心掏肺，因为我们知道，这些人是值得被我们珍惜一辈子的。", Cansee_states = 0 },
            new MicroBlog { Id = 6, UserID = 6, Title = "6我的第一个微博", Content_text = "时光荏苒，光阴飞快地流逝，我们从那小小的婴孩，长大成这么大一个人，这个过程仿佛只是一转眼间的事情。 人生苦短，有时候不禁感叹，世间有这么多美好的事，我们又何必苦苦围绕着一些不值得我们珍惜的人事物。 看开一点，看淡一点，要相信时间终究会磨去一切。 十年前我们可能会说：我相信我和他或她一定能相互陪伴，肩并肩一起走在人生的道路，永不言弃，然而十年后，风景依旧，物是人非，可我们还是要继续向前走。 当缘分已尽，也许他们会在我们的人生中留下一丝痕迹，但终究只不过是我们生命中的匆匆过客。", Cansee_states = 0 },
            new MicroBlog { Id = 7, UserID = 7, Title = "7我的第一个微博", Content_text = "　 失败时有人伸出手为我们擦眼泪，会好过成功时得到无数人伸手为我们鼓掌。 人心是永远都不会满足的，当我们艰难困苦地攀上了顶峰，回头一望，才恍然发现我们失去的比得到的还要多。试问，你后悔吗？这问题应该是没有答案的。 似乎一切都是那么的理所当然，要得到想要的东西，就必须牺牲一些东西。不同的是，在前往成功的路上，我们会经历一些风风雨雨，历经磨难与考验，披荆斩棘，一往直前不回头不停歇迈向我们的梦想与目标，然而值得我们感动的是，在这样的过程中，也许我们会遇到那么一两个人，他们没有多么显赫的身份或地位，但他们有一颗至真至诚的心，他们不会在乎你的身份，不会在乎名利，有的只是最单纯的陪伴，最善意的鼓励。大人们常说：真正的友情无关岁月，而是人生经历中渗透着惺惺相惜的真情。 患难中的朋友才是真正的朋友，我们所能做的对他们最好的报答，就是珍惜。 他们的陪伴与鼓励改变不了什么，但他们让我们存有一丝信念，相信这个世界还是美好的，相信在这遥远的路途中，终点站就是成功，就好比他们身上闪烁的光芒，已经无意间照亮了我们的人生道路。他们是我们的动力，亦是希望。", Cansee_states = 0 },
            new MicroBlog { Id = 8, UserID = 8, Title = "8我的第一个微博", Content_text = "　 感情是个很脆弱的东西，就好像泡沫一样，一击就破，又或是人与人之间那层薄薄的膜，一撕就碎。 人生路很漫长，没有谁一定可以陪谁走到最后。明天和意外，我们不知道哪个先来。一开始很多人手牵手向前走，一不小心弄丢一个，再不小心又弄丢一个，然后走着走着，不小心全都走散了，最后，只剩下孑然一身。 高处不胜寒，或许有人可以站在人生的顶峰，或许有人可以享受普通人所不能享受的一切，可难道他们不孤独不寂寞吗？难道他们没有为地位名利牺牲了什么？或许只有站在最高处，他们才能明白，人心是多么的复杂，感情是多么的脆弱。他们观看着人与人之间的勾心斗角，人们狰狞的面孔，扭曲的心思，争得你死我活、两败俱伤，最后却什么也没有得到。当初纯真善良的人在名利面前所有的一切都可以不值一提，那一颗一尘不染的心早已变得千疮百孔，浑浊不已。 而在这个时候，那些拥有高权职的人，才开始意识到，他们好像失去了生命中最重要的一个东西— 初心 。 他们开始后悔，后悔当初为什么没有好好珍惜那些以真心对待他们的人。在这个现实的社会中，他们不小心丢失了自己的心，他们怀念曾经纯白的岁月、纯真的感情，然而现在的他们什么也改变不了，也应验了那句话：“人总是要等到失去了才学会珍惜”。", Cansee_states = 0 },
            new MicroBlog { Id = 9, UserID = 9, Title = "9我的第一个微博", Content_text = "或许，我们对于一些人来说，只是一个片段，而一些人或事对我们来说，亦或是一段插曲。人生难免会有分分离离，但最重要的，是要懂得珍惜。 人生路有很多的岔口，每个人都要做不同的选择，这些选择从来都没有真正的好与坏、对或错，不管最后是什么结果，也要相信自己，因为那是自己独一无二的一部创作。最后，送大家一句话：且行且珍惜，不要将有限的光阴浪费在无限的后悔中。", Cansee_states = 0 },
            new MicroBlog { Id = 10, UserID = 10, Title = "10我的第一个微博", Content_text = "学会从容，学会淡然，既然时过境迁，过去种种，你记得也好，最好你忘掉。回眸一笑，只是感谢曾经走过的那些温润岁月。你来，我笑脸相迎，真诚相待；你走，我欣然目送，诚挚祝福。不做无谓的纠缠，不言廉价的挽留，更不要委曲求全。你能舍的下，我便放的开。", Cansee_states = 0 }
            );
        }
    }
}
