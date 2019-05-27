using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroBlogWebsite.Controllers
{
    public class AccessController : Controller
    {
        //
        // GET: /Access/

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Default()
        {
            return View();
        }

        public ActionResult Login()//登录
        {
            return View();
        }


        public ActionResult Register()//注册
        {
            return View();
        }

	}
}