using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// 我的好友分组DTO
    /// </summary>
    public class GoodFriendDto
    {
        //public int Id { get; set; }//GoodFriendID


        public int MyUserID { get; set; }//MyUserID  外键（UserInfo） 我的UserID
        public int? FollowUserID { get; set; }//FollowUserID   UserID  外键（UserInfo）    我关注的好友UserID
        public int? FansUserID { get; set; }//FansUserID    UserID  外键（UserInfo）  我的粉丝UserID  

        //public DateTime Establish { get; set; }//建立关系的时间
        public string FriendRemarks { get; set; }//对好友的备注
        public int? AitemeUserID { get; set; }//@我的人（UserID）
    }
}
