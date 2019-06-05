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


        public int MyUserID { get; set; }//MyUserID  外键（UserInfo） 我的UserID
        //[ForeignKey("MyUserID")]
        //public virtual UserInfo GoodFriendMyUserID { get; set; }



        
        public int? FollowUserID { get; set; }//FollowUserID   UserID  外键（UserInfo）    我关注的好友UserID
        //[ForeignKey("FollowUserID")]
        //public virtual UserInfo GoodFriendFollowUserID { get; set; }




        public int? FansUserID { get; set; }//FansUserID    UserID  外键（UserInfo）  我的粉丝UserID  
        //[ForeignKey("FansUserID")]
        //public virtual UserInfo GoodFriendFansUserID { get; set; }


        //public DateTime Establish { get; set; }//建立关系的时间

        [StringLength(50)]
        [Required(AllowEmptyStrings=true)]
        public string FriendRemarks { get; set; }//对好友的备注
        public int? AitemeUserID { get; set; }//@我的人（UserID）
    }
}
