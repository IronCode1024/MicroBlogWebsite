using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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





    }
}
