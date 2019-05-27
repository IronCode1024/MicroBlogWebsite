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
        public async Task AddUserInfo(string name, string email, string pwd, DateTime birthday, string region, string headPortrait, string autograph, bool states, DateTime registerTime)
        {
            //using 执行完之后立即销毁
            using (var stuSvc = new DAL.UserInfoService())
            {
                await stuSvc.AddAsync(new Models.UserInfo { UserName = name,UserEmail=email,UserPassword=pwd, UserBirthday = birthday, UserRegion = region, UserHeadPortrait = headPortrait,UserAutograph=autograph,States=states,RegisterTime=registerTime });
            }
        }
    }
}
