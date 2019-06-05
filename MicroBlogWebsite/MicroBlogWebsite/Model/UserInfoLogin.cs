using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroBlogWebsite.Model
{
    /// <summary>
    /// 登录模型类
    /// </summary>
    public class UserInfoLogin
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "*邮箱不能为空")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "*请输入合法的邮箱")]
        public string UserEmail { get; set; }      //邮箱用于登录

        [Required(ErrorMessage = "*密码不能为空")]
        public string Password { get; set; }  //用户密码

        
        public bool RememberPwd { get; set; }
    }
}