using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OthersMicrobolgManager
    {
        /// <summary>
        /// 获取用户基本信息  他人微博
        /// </summary>
        /// <param name="Uidto"></param>
        /// <returns></returns>
        public IEnumerable<Models.UserInfo> GetOtherUserInfo(string OtherUserId)
        {
            var uifSvc = new DAL.OthersMicrobolgService();
            var OtherUserInfoEntity = uifSvc.GetOtherUserInfo(int.Parse(OtherUserId));
            return OtherUserInfoEntity;
        }


        /// <summary>
        /// 他人微博主页文章  预览
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DTO.MicroBlogAndUserInfDto> GetOtherBlog(string OtherUserId)
        {
            var uifSvc = new DAL.OthersMicrobolgService();
            var OtherBlogEntity = uifSvc.GetOtherBlog(Convert.ToInt32(OtherUserId));
            return OtherBlogEntity;
        }
    }
}
