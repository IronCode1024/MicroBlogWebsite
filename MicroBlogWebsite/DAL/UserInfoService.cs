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

            var PreviewBlogEntity = (from u in DbContexts.UserInfo join mb in DbContexts.MicroBlog on u.Id equals mb.UserID select new MicroBlogAndUserInfDto { UserID=mb.UserID, UserName = u.UserName, UserHeadPortrait = u.UserHeadPortrait, Title = mb.Title, Content_text = mb.Content_text, Content_img = mb.Content_img, Content_sound = mb.Content_sound, Content_video = mb.Content_video, CreateTime = mb.CreateTime,Points_number=mb.Points_number });


//from lis1 in lists1 join lis2 in lists2 on lis1.Id equals lis2.ScId where lis1.Name == "Jack" select new Ssa { Li1 = lis1, Li2 = lis2 }).ToList();


            //IEnumerable<Models.MicroBlog> PreviewBlogEntity = DbContexts.MicroBlog.Include("MicroBlogUserID_Id").ToList<Models.MicroBlog>();
            return PreviewBlogEntity;
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


    }
}
