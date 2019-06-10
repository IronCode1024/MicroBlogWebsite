using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    /// <summary>
    /// UserInfo 业务逻辑类
    /// </summary>
    public class UserInfoManager
    {
        //添加数据方法
        //string name, string email, string pwd, DateTime birthday, string region, string headPortrait, string autograph, bool states, DateTime registerTime
        public async Task AddUserInfo(string name, string email, string pwd)
        {
            //using 执行完之后立即销毁
            //using (var uifSvc = new DAL.UserInfoService())
            //{
            var uifSvc = new DAL.UserInfoService();
            await uifSvc.AddAsync(new Models.UserInfo { UserName = name, UserEmail = email, UserPassword = pwd });
            //}
        }


        public int AddRegister(DTO.UserInfoDto UiDto)
        {
            var uifSvc = new DAL.UserInfoService();

            return uifSvc.AddRegister(UiDto);


        }

        /// <summary>
        /// 查询  登录方法
        /// </summary>
        /// <param name="uifo"></param>
        /// <returns></returns>
        public Models.UserInfo GetUserInfoWhere(Models.UserInfo uifo)
        {
            //using 执行完之后立即销毁
            var uifSvc = new DAL.UserInfoService();
            //return uifSvc.GetLogin(s =>(string.IsNullOrEmpty(s.UserEmail=email) &&  s.UserPassword == pwd));
            var loginEntity = uifSvc.GetLogin(uifo);
            return loginEntity;

        }




        /// <summary>
        /// 按最近时间获取用户头像    新加入用户
        /// </summary>
        /// <param name="Uidto"></param>
        /// <returns></returns>
        public IEnumerable<Models.UserInfo> GetUserHeadPortrait()
        {
            var uifSvc = new DAL.UserInfoService();
            var HeadPortraitEntity = uifSvc.GetUserHeadPortrait();
            return HeadPortraitEntity;

        }



       


        /// <summary>
        /// 微博文章  预览
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DTO.MicroBlogAndUserInfDto> GetPreviewBlog()
        {
            var uifSvc = new DAL.UserInfoService();
            var PreviewBlogEntity = uifSvc.GetPreviewBlog();
            return PreviewBlogEntity;
        }


        /// <summary>
        /// 热门微博用户排名
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.UserInfo> GetPopularUser()
        {
            var uifSvc = new DAL.UserInfoService();
            var PopularUserEntity = uifSvc.GetPopularUser();
            return PopularUserEntity;
        }
    }
}
