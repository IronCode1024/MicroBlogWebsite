using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DTO;

namespace DAL
{
    public class MicroBlogService : BaseService<Models.GoodFriend>
    {
        /// <summary>
        ///微博新鲜事
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.MicroBlog> GetNewThings()
        {
            var NewThingsEntity = (from u in DbContexts.MicroBlog orderby u.CreateTime descending select u).ToList();
            return NewThingsEntity;
        }


        /// <summary>
        ///微博精选文章
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.MicroBlog> GetNivo()
        {
            var GetNivoEntity = (from u in DbContexts.MicroBlog orderby u.Points_number descending select u).ToList();
            return GetNivoEntity;

        }

        /// <summary>
        /// 我的微博中显示该用户的微博
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DTO.MicroBlogAndUserInfDto> GetUserMicroBlog(UserInfo user)
        {

            var UserMicroBlog = (from u in DbContexts.UserInfo join mb in DbContexts.MicroBlog on u.Id equals mb.UserID where u.Id == user.Id orderby mb.CreateTime descending select new MicroBlogAndUserInfDto { UserID = mb.UserID, MicroBlogID = mb.Id, UserName = u.UserName, UserHeadPortrait = u.UserHeadPortrait, Title = mb.Title, Content_text = mb.Content_text, Content_img = mb.Content_img, Content_sound = mb.Content_sound, Content_video = mb.Content_video, CreateTime = mb.CreateTime, Points_number = mb.Points_number });
            return UserMicroBlog;
        }

        /// <summary>
        /// 我的微博最新关注
        /// </summary>
        /// <param name="user"></param>
        /// <param name="good"></param>
        /// <returns></returns>
        public IEnumerable<DTO.UserInfoAndGoodFriendDto> GetUserGetFriend(UserInfo user)
        {
            //var UserFriend = (from u in DbContexts.UserInfo join gf in DbContexts.GoodFriend on u.Id equals gf.MyUserID where u.Id == user.Id && gf.FollowUserID != null orderby gf.Establish descending select new UserInfoAndGoodFriendDto { Id = gf.MyUserID, UserName = u.UserName, Establish = gf.Establish, UserHeadPortrait = u.UserHeadPortrait });
            var UserFriend = (from u in DbContexts.UserInfo join gf in DbContexts.GoodFriend on u.Id equals gf.FollowUserID where gf.MyUserID == user.Id select new UserInfoAndGoodFriendDto { Id = gf.MyUserID, UserName = u.UserName, UserHeadPortrait = u.UserHeadPortrait });
            return UserFriend;
        }
        /// <summary>
        /// 我的微博删除微博
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Remove(int id)
        {
            var RemoveMymicrobolg = DbContexts.MicroBlog.Find(id);
            DbContexts.MicroBlog.Remove(RemoveMymicrobolg);

            return DbContexts.SaveChanges();

        }

        /// <summary>
        /// 发布微博
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="Mbd"></param>
        /// <returns></returns>
        public int PublishWeibo(DTO.UserInfoDto Uid,DTO.MicroBlogsDto Mbd)
        {
            Models.MicroBlog Mb = new Models.MicroBlog() { 
                UserID=Uid.Id,
                Title=Mbd.Title,
                Content_text=Mbd.Content_text,
                Content_img=Mbd.Content_img,
                Points_number=0,
                Place=Mbd.Place,
                Cansee_states=0
            };
            DbContexts.MicroBlog.Add(Mb);
            return DbContexts.SaveChanges();
        }



    }
}
