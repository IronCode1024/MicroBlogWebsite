using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace MicroBlogWebsite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        /// <summary>
        /// 我的首页 登录之后
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()//显示页面方法
        {
            if (Session["User_Login"].ToString() !=null)//登录成功
            {
                return View();
            }
            else
            {
                return Redirect(Url.Action("Default", "Access"));
            }
        }

        //[HttpPost]
        //public ActionResult Index(UserInfo ui)
        //{
        //    if (Session["User_Login"].ToString() == "1")//登录成功
        //    {
        //        return Redirect(Url.Action("Index"));
        //    }
        //    else
        //    {
        //        return Redirect(Url.Action("Default", "Access"));
        //    }
            
        //}

        /// <summary>
        /// 我的微博=>我的微博的基本信息=>编辑自己得微博（增删改查）（徐梦琴）
        /// </summary>
        /// <returns></returns>
        public ActionResult Mymicrobolg()//显示页面方法
        {
            if (Session["User_Login"].ToString() == "1")//登录成功
            {
                return View();
            }
            else
            {
                return Redirect(Url.Action("Default", "Access"));
            }
            
        }
       


        /// <summary>
        /// 好友列表=>分组、添加好友、编辑好友信息（备注）、黑名单、取消关注(徐一鸣)
        /// </summary>
        /// <returns></returns>
        public ActionResult Myfriendlist()//显示页面方法
        {
            if (Session["User_Login"].ToString() == "1")//登录成功
            {
                return View();
            }
            else
            {
                return Redirect(Url.Action("Default", "Access"));
            }
        }

        
        /// <summary>
        /// 个人中心，个人信息=>用户的个人自己的信息，自定义信息。（杨洲）
        /// </summary>
        /// <returns></returns>
        public ActionResult Personalcenter()//显示页面方法
        {
            if (Session["User_Login"].ToString() == "1")//登录成功
            {
                return View();
            }
            else
            {
                return Redirect(Url.Action("Default", "Access"));
            }
        }
	}
}