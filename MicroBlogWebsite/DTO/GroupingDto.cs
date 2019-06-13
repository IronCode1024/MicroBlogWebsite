using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// 分组信息DTO
    /// </summary>
    public class GroupingDto
    {
        //public int Id { get; set; }//GroupID
        public string GroupName { get; set; }//组别名称
        public int? FriendUserID { get; set; }//好友UserID
        public int MyUserID { get; set; }//我的UserID
    }
}
