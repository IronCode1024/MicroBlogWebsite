using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using System.Text.RegularExpressions;
using System.IO;

namespace MicroBlogWebsite.Controllers
{
    public class HomeController : Controller
    {
        //protected void Page_Error(object sender, EventArgs e)
        //{
        //    Exception ex = Server.GetLastError();
        //    if (ex is HttpRequestValidationException)
        //    {
        //        Response.Write("请您输入合法字符串。");
        //        Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()。   
        //    }
        //} 
        public HomeController()
        {

        }

        //=========================================================================基本实例化初始化对象=====================================================================//
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
        //=========================================================================基本实例化初始化对象=====================================================================//


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
            else//登录失败，跳转回登录页面
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



        //=================================================================我的微博开始====================================================================//

        /// <summary>
        /// 我的微博=>我的微博的基本信息=>编辑自己得微博（增删改查）（徐梦琴）
        /// </summary>
        /// <returns></returns>
        public ActionResult Mymicrobolg()//显示页面方法
        {
            if (Session["User_Login"] != null)//登录成功
            {
                //微博显示所有微博
                UserInfo user = new UserInfo();
                //user.Id =Convert.ToInt32(Request["userId"]);
                //var i = Request["userId"];

                user.Id = Convert.ToInt32(Session["User_Login"]);
                IEnumerable<DTO.MicroBlogAndUserInfDto> listUserMicroBlog = MbmBll.GetUserMicroBlog(user);
                ViewBag.listUserMicroBlog = listUserMicroBlog;
                //最近关注的好友
                user.Id = Convert.ToInt32(Session["User_Login"]);
                IEnumerable<DTO.UserInfoAndGoodFriendDto> listUserFriend = MbmBll.GetUserGetFriend(user);
                ViewBag.listUserFriend = listUserFriend;


                //关注、粉丝、微博数 DAL
                int[] FFBs = UimBll.FFB(Convert.ToInt32(Session["User_Login"]));
                ViewBag.Follows = FFBs[0];
                ViewBag.Fans = FFBs[1];
                ViewBag.Blogs = FFBs[2];

                return View();

            }
            else
            {
                return Redirect(Url.Action("Default", "Access"));
            }
        }
        public int Mymicrobolgs()//删除的方法
        {
            int id = Convert.ToInt32(Request["id"]);
            int msg = MbmBll.Remove(id);
            return msg;
        }

        /// <summary>
        /// 发布微博
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        [HttpPost]
        public int PublishWeibo(DTO.UserInfoDto Uid, DTO.MicroBlogsDto Mbd)
        {
            Uid.Id = Convert.ToInt32(Session["User_Login"]);//发布用户的ID，登录用户
            //截取标题
            string[] titles = GetP(Request["PublishWeiboHtml"]);
            string contentTitle = titles[0];
            //foreach (string item in titles)
            //{
            //    contentTitle += item;
            //}

            //截取图片
            string[] content = GetHtmlImageUrlList(Request["PublishWeiboHtml"]);
            string contentImg = "";
            foreach (string item in content)
            {
                contentImg += item;
            }


            Mbd.Content_text = Request["PublishWeiboHtml"];//微博内容 AJAX传过来的值
            Mbd.Content_img = contentImg;
            Mbd.Title = contentTitle;

            return MbmBll.PublishWeibo(Uid, Mbd);
        }

        /// <summary>   
        /// 取得HTML中所有图片的 URL。   
        /// </summary>   
        /// <param name="sHtmlText">HTML代码</param>   
        /// <returns>图片的URL列表</returns>   
        public static string[] GetHtmlImageUrlList(string sHtmlText)
        {
            // 定义正则表达式用来匹配 img 标签   
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串   
            MatchCollection matches = regImg.Matches(sHtmlText);
            //int i = 0;
            string[] sUrlList = new string[matches.Count];

            // 取得匹配项列表   
            foreach (Match match in matches)
            {
                string hozhui = (match.Groups["imgUrl"].Value).Split('.').Last();//获取图片的后缀名
                if (hozhui != "gif")//判断后缀是否为gif，如果不是gif就将其取出，存到img字段中，当做文章的封面图片
                {
                    sUrlList[0] = match.Groups["imgUrl"].Value;
                    return sUrlList;
                }
                else
                {
                    GetHtmlImageUrlList("");
                }
            }
            return sUrlList;
        }

        public static string[] GetP(string sHtmlText)
        {
            //(?is)(?<=<P>).*?(?=</P>)
            System.Text.RegularExpressions.Regex Reg = new System.Text.RegularExpressions.Regex(@"<P>.*?</P>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //string Content = Reg.Match(item.Content_text).Value;

            System.Text.RegularExpressions.MatchCollection matches = Reg.Matches(sHtmlText);
            //int i = 0;
            string[] sUrlList = new string[matches.Count];
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                sUrlList[0] = match.ToString();
                return sUrlList;
            }
            return sUrlList;
            
        }

        //=================================================================我的微博结束====================================================================//




        //=================================================================好友列表开始====================================================================//

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
        //=================================================================好友列表结束====================================================================//


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

        //预览图片的方法
        [HttpPost]
        public string tu()
        {
            Guid g = new Guid();
            HttpPostedFileBase img = Request.Files["file"];
            string p = "";
            //判断是否上传了图片
            if (img != null)
            {
                p = "/Content/images/Personalcenter/" + g.ToString() + Path.GetFileName(img.FileName);
                img.SaveAs(Server.MapPath(p));
            }
            return p;

        }
        //保存图片
        [HttpPost]
        public int bao(string lu)
        {
            DTO.UserInfoDto du = new DTO.UserInfoDto();
            //先暂时给
            du.Id = 1;
            du.UserHeadPortrait = lu;
            int i = UimBll.bao(du);
            return 0;
        }

        //修改的方法  FormCollection Form 通过表单集合拿值 注意name
        [HttpPost]
        public ActionResult udate(DTO.UserInfoDto ta, FormCollection Form)//测试传值
        {
            DTO.UserInfoDto du = new DTO.UserInfoDto();
            du.Id = 1;//先暂时给
            du.UserName = ta.UserName;//用户名
            du.UserEmail = ta.UserEmail;//邮箱
            du.UserAutograph = ta.UserAutograph;//
            du.UserSex = ta.UserSex;//性别
            //地区 拼接
            du.UserRegion = Form["UserRegion"] + Form["UserRegion2"];
            //生日
            du.UserBirthday = DateTime.Parse(Form["year"] + "-" + Form["moth"] + "-" + Form["day"]);


            //ViewBag.a = ta.Id;
            //ViewBag.b = ta.UserName;
            //ViewBag.c = ta.UserEmail;
            //ViewBag.d = ta.UserAutograph;
            //ViewBag.e = ta.UserSex;
            //通过name拿值
            //ViewBag.f = Form["UserRegion"];  
            //ViewBag.g = Form["UserRegion2"];

            //ViewBag.l = Form["year"];
            //ViewBag.m = Form["moth"];
            //ViewBag.n = Form["day"];


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
            if (UserIdNum != "")
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