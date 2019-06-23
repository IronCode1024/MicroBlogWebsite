using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DTO;

namespace BLL
{
    /// <summary>
    /// MicroBlogManager  微博文章业务逻辑类
    /// </summary>
    public class MicroBlogManager
    {
        /// <summary>
        ///微博新鲜事
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.MicroBlog> GetNewThings()
        {
            var uifSvc = new DAL.MicroBlogService();
            var NewThingsEntity = uifSvc.GetNewThings();
            return NewThingsEntity;

        }

        /// <summary>
        ///微博精选文章
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.MicroBlog> GetNivo()
        {
            var uifSvc = new DAL.MicroBlogService();
            var GetNivoEntity = uifSvc.GetNivo();
            return GetNivoEntity;
        }

        /// <summary>
        /// 我的微博中显示该用户的微博
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MicroBlogAndUserInfDto> GetUserMicroBlog(UserInfo user)
        {
            var getum = new DAL.MicroBlogService();
            var UserMicroBlog = getum.GetUserMicroBlog(user);
            return UserMicroBlog;

        }
        /// <summary>
        /// 我的微博最近关注用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<UserInfoAndGoodFriendDto> GetUserGetFriend(UserInfo user)
        {
            var getum = new DAL.MicroBlogService();
            var UserFriend = getum.GetUserGetFriend(user);
            return UserFriend;
        }

        /// <summary>
        /// 删除微博 方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Remove(int id)
        {
            var getum = new DAL.MicroBlogService();
            int RemoveMymicrobolg = getum.Remove(id);
            return RemoveMymicrobolg;
        }



        /// <summary>
        /// 发布微博
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="Mbd"></param>
        /// <returns></returns>
        public int PublishWeibo(DTO.UserInfoDto Uid, DTO.MicroBlogsDto Mbd)
        {
            var uifSvc = new DAL.MicroBlogService();
            return uifSvc.PublishWeibo(Uid,Mbd);
        }
    }
}
