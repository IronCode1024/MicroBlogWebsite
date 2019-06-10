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

        public int? FansUserID { get; set; }//粉丝数量
    }
}
