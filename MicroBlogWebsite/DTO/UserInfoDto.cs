using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }//用户名
        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public string UserSex { get; set; }

        public DateTime UserBirthday { get; set; }//生日

        public int Age { get; set; }//年齡，不映射到数据库，此字段为计算值（根据生日计算年龄）

        public string UserRegion { get; set; }//地区（省市）

        public string UserHeadPortrait { get; set; }//头像

        public string UserAutograph { get; set; }//个性签名
        public bool States { get; set; }//在线状态
    }
}
