using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class UserInfoService : BaseService<Models.UserInfo>
    {

        /// <summary>
        /// 注册方法
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public int AddRegister(DTO.UserInfoDto Uidto)
        {
            //return DbContext.UserInfo.Where(whereLambda).AsQueryable();
            Models.UserInfo Userlist = new Models.UserInfo() {
                UserName = Uidto.UserName,
                UserEmail = Uidto.UserEmail,
                UserPassword = Uidto.UserPassword
            };
            DbContexts.UserInfo.Add(Userlist);
            int i = DbContexts.SaveChanges();
            return i;
        }


        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public Models.UserInfo GetLogin(Models.UserInfo uifo)
        {
            //return DbContext.UserInfo.Where(whereLambda).AsQueryable();
            var loingEntity = DbContexts.UserInfo.Where(w => w.UserEmail == uifo.UserEmail && w.UserPassword==uifo.UserPassword).FirstOrDefault();
            return loingEntity;
        }


        /// <summary>
        /// 找回密码方法
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public int ForgetThePwd(DTO.UserInfoDto Uidto)
        {
            //根据邮箱修改密码
            var ForgetThePwdEntity = DbContexts.UserInfo.Where(p => p.UserEmail == Uidto.UserEmail).First();
            ForgetThePwdEntity.UserPassword = Uidto.UserPassword;
            int i = DbContexts.SaveChanges();
            return i;
        }



        /// <summary>
        /// 登录成功后查询出用户的ID
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IEnumerable<Models.UserInfo> getUserId(string email)
        {
            var UserId = (from p in DbContexts.UserInfo where p.UserEmail == email select p).ToList();
            return UserId;
        }


        /// <summary>
        /// 按最近时间获取用户头像    新加入用户
        /// </summary>
        /// <param name="Uidto"></param>
        /// <returns></returns>
        public IEnumerable<Models.UserInfo> GetUserHeadPortrait()
        {
            var HeadPortraitEntity = (from u in DbContexts.UserInfo orderby u.CreateTime select u).ToList();
            return HeadPortraitEntity;
        }

        


        /// <summary>
        /// 微博文章  预览
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MicroBlogAndUserInfDto> GetPreviewBlog()
        {
            //var PreviewBlogEntity = (from u in DbContexts.MicroBlog orderby u.CreateTime descending select u).ToList();

            var PreviewBlogEntity = (from u in DbContexts.UserInfo join mb in DbContexts.MicroBlog on u.Id equals mb.UserID orderby mb.CreateTime descending select new MicroBlogAndUserInfDto { Id=mb.Id, UserID=mb.UserID, UserName = u.UserName, UserHeadPortrait = u.UserHeadPortrait, Title = mb.Title, Content_text = mb.Content_text, Content_img = mb.Content_img, Content_sound = mb.Content_sound, Content_video = mb.Content_video, CreateTime = mb.CreateTime,Points_number=mb.Points_number });


//from lis1 in lists1 join lis2 in lists2 on lis1.Id equals lis2.ScId where lis1.Name == "Jack" select new Ssa { Li1 = lis1, Li2 = lis2 }).ToList();


            //IEnumerable<Models.MicroBlog> PreviewBlogEntity = DbContexts.MicroBlog.Include("MicroBlogUserID_Id").ToList<Models.MicroBlog>();
            return PreviewBlogEntity;
        }

        /// <summary>
        /// 增加点赞数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Points"></param>
        public int Points_number(int id)
        {
            var PreviewBlogEntity = (from mb in DbContexts.MicroBlog where mb.Id==id select new { mb.Points_number });
            int num = 0;
            foreach (var item in PreviewBlogEntity)
            {
                num = item.Points_number;
            }
            num += 1;
            var dd = DbContexts.MicroBlog.Find(id);
            dd.Points_number = num;
            return DbContexts.SaveChanges();

            //Models.MicroBlog mbs = new Models.MicroBlog() { 
            //    Points_number=num
            //};

        }


        /// <summary>
        /// 热门微博用户排名
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.UserInfo> GetPopularUser()
        {
            var PopularUserEntity = (from u in DbContexts.UserInfo orderby u.UserFansNum descending select u);
            return PopularUserEntity;
        }

        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 关注、粉丝、微博数 DAL
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int[] FFB(int UserId)
        {
            //关注数
            var FollowUserID = (from u in DbContexts.UserInfo join gf in DbContexts.GoodFriend on u.Id equals gf.MyUserID where u.Id == UserId && gf.FollowUserID != null select new UserInfoAndGoodFriendDto { Id = gf.MyUserID, UserName = u.UserName, UserHeadPortrait = u.UserHeadPortrait });
            int FollowUser = FollowUserID.Count();
            //粉丝数
            var FansUserID = (from u in DbContexts.UserInfo join gf in DbContexts.GoodFriend on u.Id equals gf.MyUserID where u.Id == UserId && gf.FansUserID != null select new UserInfoAndGoodFriendDto { Id = gf.MyUserID, UserName = u.UserName, UserHeadPortrait = u.UserHeadPortrait });
            int FansUser = FansUserID.Count();
            //微博数
            var UserMicroBlog = (from u in DbContexts.UserInfo join mb in DbContexts.MicroBlog on u.Id equals mb.UserID where u.Id == UserId select new MicroBlogAndUserInfDto { UserID = mb.UserID, UserName = u.UserName, UserHeadPortrait = u.UserHeadPortrait, Title = mb.Title, Content_text = mb.Content_text, Content_img = mb.Content_img, Content_sound = mb.Content_sound, Content_video = mb.Content_video, CreateTime = mb.CreateTime, Points_number = mb.Points_number });
            int MicroBlog = UserMicroBlog.Count();

            //FansFlowerMicroBlogCountDto ffb = new FansFlowerMicroBlogCountDto();
            //ffb.FollowUser = FollowUser;
            //ffb.FansUser = FansUser;
            //ffb.MicroBlog = MicroBlog;

            int[] num = new int[3] { FollowUser, FansUser, MicroBlog };
            return num;
        }
        /////////////////////////////////////////////////////////////////////////////////////////

        //================================编辑资料开始=====================================//

        //通过登陆后的id显示一些信息
        public Models.UserInfo xian(int id)
        {

            var ui = DbContexts.UserInfo.Where(a => a.Id == id).FirstOrDefault();
            return ui;
        }
        //保存头像
        public int bao(DTO.UserInfoDto du)
        {
            var ui = DbContexts.UserInfo.Find(du.Id);
            ui.UserHeadPortrait = du.UserHeadPortrait;

            return DbContexts.SaveChanges();
        }
        //保存资料
        public int update(DTO.UserInfoDto du)
        {
            var ui = DbContexts.UserInfo.Find(du.Id);
            ui.UserName = du.UserName;
            ui.UserEmail = du.UserEmail;
            ui.UserAutograph = du.UserAutograph;
            ui.UserSex = du.UserSex;
            ui.UserRegion = du.UserRegion;
            ui.UserBirthday = du.UserBirthday;
            return DbContexts.SaveChanges();
        }

        //================================编辑资料结束=====================================//

    }
}
