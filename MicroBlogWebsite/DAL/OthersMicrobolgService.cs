using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    /// <summary>
    /// 他人微博显示数据
    /// </summary>
    public class OthersMicrobolgService:BaseService<Models.UserInfo>
    {

        /// <summary>
        /// 获取用户基本信息  他人微博
        /// </summary>
        /// <param name="Uidto"></param>
        /// <returns></returns>
        public IEnumerable<Models.UserInfo> GetOtherUserInfo(int OtherUserId)
        {
            var OtherUserInfoEntity = (DbContexts.UserInfo.Where(u => u.Id == OtherUserId)).ToList();
            return OtherUserInfoEntity;
        }


        /// <summary>
        /// 他人微博主页文章  预览
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MicroBlogAndUserInfDto> GetOtherBlog(int OtherUserId)
        {
            //var PreviewBlogEntity = (from u in DbContexts.MicroBlog orderby u.CreateTime descending select u).ToList();

            var OtherBlogEntity = (from u in DbContexts.UserInfo join mb in DbContexts.MicroBlog on u.Id equals mb.UserID where u.Id == OtherUserId select new MicroBlogAndUserInfDto { Id=mb.Id, UserID = mb.UserID, UserName = u.UserName, UserHeadPortrait = u.UserHeadPortrait, Title = mb.Title, Content_text = mb.Content_text, Content_img = mb.Content_img, Content_sound = mb.Content_sound, Content_video = mb.Content_video, CreateTime = mb.CreateTime, Points_number = mb.Points_number });
            return OtherBlogEntity;
        }
    }
}
