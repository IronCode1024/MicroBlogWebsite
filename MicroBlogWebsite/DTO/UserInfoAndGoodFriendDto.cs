using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserInfoAndGoodFriendDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }//用户名
        public int MyUserID { get; set; }//我的用户名
        public int FollowUserID { get; set; }//我的关注好友
        public int FansUserID { get; set; }//我的粉丝
        public string FriendRemarks { get; set; }//对好友的备注
        public int AitemeUserID { get; set; }//@我的人（UserID）
        public string UserHeadPortrait { get; set; }//头像
        public DateTime Establish { get; set; }//建立关系的时间

        //public int? FansUserID { get; set; }//粉丝数量
    }
}
