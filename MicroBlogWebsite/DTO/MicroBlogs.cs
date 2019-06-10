using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MicroBlogs
    {
        public int UserID { get; set; }//UserID  外键（UserInfo）
        public string Title { get; set; }//标题
        public string Content_text { get; set; }//内容（文本）
        public string Content_img { get; set; }//内容（图片）
        public string Content_video { get; set; }//内容（视频）
        public string Content_sound { get; set; }//内容（音频）
        public int Points_number { get; set; }//点赞数量
        public string Place { get; set; }//发布地点（省市）
        public int Cansee_states { get; set; }//可见状态，0所有人可见，1只有好友可见,2仅自己可见（0/1/2）

        /// <summary>
        /// 时间差
        /// </summary>
        public DateTime TimeDifference { get; set; }
    }
}
