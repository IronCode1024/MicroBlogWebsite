using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Tana_UserInfo")]
    public class UserInfo:BaseEntity
    {
        //public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public DateTime UserBirthday { get; set; }
        public string UserRegion { get; set; }
        public string UserHeadPortrait { get; set; }
        public string UserAutograph { get; set; }
        public bool States { get; set; }
        public DateTime RegisterTime { get; set; }

    }
}
