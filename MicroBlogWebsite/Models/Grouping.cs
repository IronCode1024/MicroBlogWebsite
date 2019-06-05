using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Tana_Grouping")]
    public class Grouping : BaseEntity
    {
        //public int Id { get; set; }//GroupID
        public string GroupName { get; set; }//组别名称
        public int? FriendUserID { get; set; }//好友UserID
        public int MyUserID { get; set; }//我的UserID

    }
}
