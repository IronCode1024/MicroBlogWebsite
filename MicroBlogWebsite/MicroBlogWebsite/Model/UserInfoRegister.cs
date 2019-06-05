using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroBlogWebsite.Model
{
    /// <summary>
    /// 注册模型类
    /// </summary>
    public class UserInfoRegister
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "*用户名不能为空")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*邮箱不能为空")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "*请输入合法的邮箱")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "*密码不能为空")]
        [StringLength(100, ErrorMessage = "*{0}的长度至少为{2}个字符。",
        MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Required(ErrorMessage = "*确认密码不能为空")]
        [Compare("Password", ErrorMessage = "*两次输入的密码不一致")]
        public string ConfirmPassword { get; set; }//确认密码


        public DateTime UserBirthday { get; set; }//生日
        public string UserRegion { get; set; }
        public string UserHeadPortrait { get; set; }
        public string UserAutograph { get; set; }
        public bool States { get; set; }
        public DateTime RegisterTime { get; set; }


        [Required(ErrorMessage = "*验证码不能为空")]
        public string VerificationCode { get; set; }  //验证码
    }
}