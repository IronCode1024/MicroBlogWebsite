using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MicroBlogAndUserInfDto
    {
        public int MicroBlogID { get; set; }//Id  微博ID
        public int UserID { get; set; }//UserID  外键（UserInfo）
        public string Title { get; set; }//标题
        public string Content_text { get; set; }//内容（文本）
        public string Content_img { get; set; }//内容（图片）
        public string Content_video { get; set; }//内容（视频）
        public string Content_sound { get; set; }//内容（音频）
        public int Points_number { get; set; }//点赞数量
        public string Place { get; set; }//发布地点（省市）
        public int Cansee_states { get; set; }//可见状态，0所有人可见，1只有好友可见,2仅自己可见（0/1/2）

        public DateTime CreateTime { get; set; }

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
