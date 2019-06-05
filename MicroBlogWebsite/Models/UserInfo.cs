using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Tana_UserInfo")]
    public class UserInfo:BaseEntity
    {
        public UserInfo()
        {
            if (UserBirthday!=null)
            {
                this.Age = Convert.ToInt32(DateTime.Now.Year - UserBirthday.Value.Year);//计算年龄
            }
            this.States=false;//默认在线状态为false
        }

        //public int Id { get; set; }
        [StringLength(50),Required]
        public string UserName { get; set; }//用户名
        [StringLength(150),Required]
        public string UserEmail { get; set; }
        [MaxLength(16)]
        [MinLength(6)]
        [Required]
        public string UserPassword { get; set; }

        [StringLength(4)]
        public string UserSex { get; set; }
        
        //[Required(AllowEmptyStrings=true)]//允许为空
        public DateTime? UserBirthday { get; set; }//生日

        [NotMapped]
        public int Age { get; set; }//年齡，不映射到数据库，此字段为计算值（根据生日计算年龄）

        //[Required(AllowEmptyStrings = false)]//允许为空
        public string UserRegion { get; set; }//地区（省市）

        //[Required(AllowEmptyStrings = false)]//允许为空
        public string UserHeadPortrait { get; set; }//头像

        //[Required(AllowEmptyStrings=false)]//允许为空
        public string UserAutograph { get; set; }//个性签名
        public bool States { get; set; }//在线状态
        //public DateTime RegisterTime { get; set; }





        ////外键    微博文章表  关联UserInfo  Id   UserID
        //[InverseProperty("MicroBlogUserID")]
        //public virtual ICollection<MicroBlog> MicroBlogUserID { get; set; }

        

        ////外鍵  好友表   关联UserInfo   Id
        //[InverseProperty("GoodFriendMyUserID")]
        //public virtual ICollection<GoodFriend> GoodFriendMyUserID { get; set; }

        //[InverseProperty("GoodFriendFollowUserID")]
        //public virtual ICollection<GoodFriend> GoodFriendFollowUserID { get; set; }

        //[InverseProperty("GoodFriendFansUserID")]
        //public virtual ICollection<GoodFriend> GoodFriendFansUserID { get; set; }
    }
}
