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
        public HomeController()
        {
            
        }
        /// <summary>
        /// UimBll 用户管理BLL类
        /// </summary>
        private BLL.UserInfoManager UimBll = new BLL.UserInfoManager();
        /// <summary>
        /// MbmBll 用户微博管理类
        /// </summary>
        private BLL.MicroBlogManager MbmBll = new BLL.MicroBlogManager();
        /// <summary>
        /// OmmBll 他人微博页面微博文章管理类
        /// </summary>
        private BLL.OthersMicrobolgManager OmmBll = new OthersMicrobolgManager();
        /// <summary>
        /// 评论
        /// </summary>
        private BLL.CommentManager CemBll = new CommentManager();
        /// <summary>
        /// 好友
        /// </summary>
        private BLL.GoodFriendManager Gfm = new GoodFriendManager();
        /// <summary>
        /// 好友分组
        /// </summary>
        private BLL.GroupingManager Gm = new GroupingManager();

        //
        // GET: /Home/
        /// <summary>
        /// 我的首页 登录之后
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()//显示页面方法
        {
            if (Session["User_Login"] != null)//登录成功
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
            if (Session["User_Login"] != null)//登录成功
            {
                if ( Request["userId"]!=null)
                {
                    return View();
                }
                else
                {
                    return View();
                }
                
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
            if (Session["User_Login"] != null)//登录成功
            {
                return View();
            }
            else
            {
                return Redirect(Url.Action("Default", "Access"));
            }
        }



        //=================================================================个人中心====================================================================//

        /// <summary>
        /// 个人中心，个人信息=>用户的个人自己的信息，自定义信息。（杨洲）
        /// </summary>
        /// <returns></returns>
        public ActionResult Personalcenter()//显示页面方法
        {
            if (Session["User_Login"] != null)//登录成功
            {
                //暂时给个id
                //Tana_UserInfo userinfo = db.Tana_UserInfo.Find(1);
                return View();
            }
            else
            {
                return Redirect(Url.Action("Default", "Access"));
            }
        }


        //修改的方法  FormCollection Form 通过表单集合拿值 注意name
        [HttpPost]
        public ActionResult index(DTO.UserInfoDto ta, FormCollection Form)//测试传值
        {
            ViewBag.a = ta.Id;
            ViewBag.b = ta.UserName;
            ViewBag.c = ta.UserEmail;
            ViewBag.d = ta.UserAutograph;
            ViewBag.e = ta.UserSex;
            //通过name拿值
            ViewBag.f = Form["UserRegion"];  
            ViewBag.g = Form["UserRegion2"];

            ViewBag.l = Form["year"];
            ViewBag.m = Form["moth"];
            ViewBag.n = Form["day"];


            ViewBag.w = Form["UserPassword2"];

            return View();
        }

        //=================================================================个人中心====================================================================//



        /// <summary>
        /// 他人的微博主页，相对于当前登录用户
        /// </summary>
        /// <returns></returns>
        public ActionResult OthersMicrobolg()
        {
            string UserIdNum = Request["user"];//当登录用户点击他人微博文章或者用户头像时跳转到此页面，传过来的此用户的Id
            if (UserIdNum!="")
            {
                //他人用户基本信息
                IEnumerable<Models.UserInfo> listOtherUserInfo = OmmBll.GetOtherUserInfo(UserIdNum);
                foreach (Models.UserInfo item in listOtherUserInfo)
                {
                    ViewData["OtherHeadPortrait"] = item.UserHeadPortrait;
                    ViewBag.OtherUserName = item.UserName;
                    ViewBag.OtherUserAutograph = item.UserAutograph;//个性签名
                }
                ViewBag.listOtherUserInfo = listOtherUserInfo;

                //微博内容     预览
                IEnumerable<DTO.MicroBlogAndUserInfDto> listOtherBlog = OmmBll.GetOtherBlog(UserIdNum);
                ViewBag.listOtherBlog = listOtherBlog;
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}