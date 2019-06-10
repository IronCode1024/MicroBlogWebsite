using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MicroBlogWebsite.Controllers
{
    public class AccessController : Controller
    {
        static string InputVerificationCode = "";
        /// <summary>
        /// UimBll 用户管理BLL类
        /// </summary>
        private BLL.UserInfoManager UimBll = new BLL.UserInfoManager();
        private BLL.MicroBlogManager MbmBll= new BLL.MicroBlogManager();

        //
        // GET: /Access/

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Default()
        {
            //用户头像  九宫格
            IEnumerable<Models.UserInfo> listUserHeadPortrait = UimBll.GetUserHeadPortrait();
            ViewBag.listUserHeadPortrait = listUserHeadPortrait;

            //微博新鲜事儿
            IEnumerable<Models.MicroBlog> listNewThings = MbmBll.GetNewThings();
            ViewBag.listNewThings = listNewThings;

            //微博精选文章
            IEnumerable<Models.MicroBlog> listNivo = MbmBll.GetNivo();
            ViewBag.listNivo = listNivo;

            //微博内容     预览
            IEnumerable<DTO.MicroBlogAndUserInfDto> listPreviewBlog = UimBll.GetPreviewBlog();
            ViewBag.listPreviewBlog = listPreviewBlog;

            //热门微博用户排名   根据粉丝数量排序
            IEnumerable<Models.UserInfo> listPopularUser = UimBll.GetPopularUser();
            ViewBag.listPopularUser = listPopularUser;

            return View();
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult OutLogin()
        {
            Session["User_Login"] = null;//清空session
            return Redirect(Url.Action("Default", "Access"));
        }


        [HttpGet]
        public ActionResult Login()//登录
        {
            return View();
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="Uil"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(Model.UserInfoLogin Uifl, Models.UserInfo Uifo)
        {
            string Email = Request["UserEmail"];
            string pwd = Request["Password"];
            if (Email != "" && pwd != "")//验证是否通过
            {
                //ViewBag.LoginErr = Email;
                //return View();
                Uifo.UserEmail = Email;
                Uifo.UserPassword = pwd;
                var loginEntity = UimBll.GetUserInfoWhere(Uifo);
                if (loginEntity == null)
                {
                    ViewBag.LoginErr = "*邮箱或密码错误";
                    return View();
                }
                else
                {
                    Session["User_Login"] = "1";//登录成功，给session赋值
                    //Session.Timeout = 1;
                    return Redirect(Url.Action("Index", "Home"));
                }

            }
            else
            {
                //ViewBag.LoginErr = "*邮箱或密码错误";
                return View();
            }
        }


        public ActionResult Register()//注册
        {
            return View();
        }

        [HttpPost]
        public int RegisterPost(DTO.UserInfoDto UiDto)//注册
        {
            string VerificationCode = Request["InputVerificationCode"];
            if (VerificationCode == InputVerificationCode)
            {
                string UserName = Request["UserName"];
                string UserEmail = Request["UserEmail"];
                string UserPassword = Request["Password"];
                UiDto.UserName = UserName;
                UiDto.UserEmail = UserEmail;
                UiDto.UserPassword = UserPassword;
                int RregisterEntity = UimBll.AddRegister(UiDto);
                return RregisterEntity;
            }
            else
            {
                int msg = -101;//验证码输入错误
                return msg;
            }
        }

        [HttpPost]
        public JsonResult VerificationCode(Model.UserInfoRegister Uifr)
        {
            InputVerificationCode = "";//初始化接收验证码的变量为空
            try
            {
                //collection["Email"]
                string Email = Request["UserEmail"];
                Random Rdm = new Random();
                //产生0到10的随机数

                for (int i = 0; i < 6; i++)//六位数验证码
                {
                    InputVerificationCode += Rdm.Next(10).ToString();
                }

                //SmtpServer: 发送电邮所使用的 SMTP 服务器的名称。
                //SmtpPort: 发送 SMTP transactions(电邮) 所用的服务器端口。
                //EnableSsl: True，如果服务器应该使用 SSL(Secure Socket Layer) 加密。
                //UserName: 发送电邮所用的 SMTP email 账户的名称。
                //Password: SMTP 电邮账户的密码。
                //From: 出现在 from 栏中的电邮地址（通常与 UserName 相同）。
                WebMail.SmtpServer = "smtp.qq.com";/*发送方邮件服务器*/
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "1453190098";
                WebMail.Password = "ltzmudrssqzfhihe";/*ltzmudrssqzfhihe  -邮箱授权码*/
                WebMail.From = "1453190098@qq.com"; /*发送方邮箱*/

                WebMail.Send(Email, "踏浪微博www.talang.com", "您好！您正在注册踏浪微博， " + "验证码为：" + InputVerificationCode.ToString());//2457284169@qq.com

                ViewBag.fasong = "发送成功";
                return Json(InputVerificationCode);
                //ViewBag.failInSend = yzm;
            }
            catch (Exception e)
            {
                string Err = e.Message;
                //string js = "<script>alert('" + a + "')</script>";
                //return JavaScript(js);
                ViewBag.failInSend = "*发送失败";
                ViewBag.fasong = "获取"; //fasong 发送邮件返回的字符串
                return Json(InputVerificationCode);
                //return Content("发送失败！");
            }
        }

    }
}