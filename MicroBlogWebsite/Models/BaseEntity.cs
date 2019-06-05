using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreateTime = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }

        //[DefaultValue(DateTime.Now)]//默认值    另外一种方式类的构造函数中进行赋值CreateTime="默认值";
        public DateTime CreateTime { get;set; }

        [DefaultValue(0)]
        public bool IsRemoved { get; set; }
    }
}
