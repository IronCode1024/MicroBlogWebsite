using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Tana_GoodFriend")]
    public class GoodFriend : BaseEntity
    {
        //public int Id { get; set; }//GoodFriendID

        [ForeignKey("")]
        public int UserID { get; set; }//UserID  外键（UserInfo） 我的UserID
        //public UserInfo UserInfo { get; set; }



        [ForeignKey("")]
        public int FollowUserID { get; set; }//FollowUserID   UserID  外键（UserInfo）    我关注的好友UserID
        //public UserInfo UserInfos { get; set; }



        [ForeignKey("")]
        //[Required]
        public int FansUserID { get; set; }//FansUserID    UserID  外键（UserInfo）  我的粉丝UserID  
        //public UserInfo UserInfoss { get; set; }


        public DateTime Establish { get; set; }//建立关系的时间
        public string FriendRemarks { get; set; }//对好友的备注
        public int AitemeUserID { get; set; }//@我的人（UserID）
    }
}
