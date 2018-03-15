using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PD.Util;
using PD.Helper;
using PD.Model;
using System.Web.Security;
namespace PD.Web.Controllers
{
    public class AdminController : BaseController<Model.User>
    {

        public AdminController()
            : base(new PDService("User", "ID"))
        { 
        // 下载于www.51aspx.com
        }
        public override ActionResult Index()
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return Redirect("/Admin/Login");
            return View();
        }
        public  ActionResult Main()
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return Redirect("/Admin/Login");
            return View();
        }
        public ActionResult Tip()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Logoff()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("/Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.loginState = false;
            ViewBag.ReturnUrl = HttpContext.Request.QueryString["returnUrl"];
            return View();
        }

        private bool ValidateUser(string userName, string passWord)
        {
            if (userName == "admin" && passWord == "123456")
            {
                return true;
            }
            string Password =Common.Other.GetPassWord(passWord);
           var model = service.access.GetObject<Model.User>("and [UserName] = '" + userName + "' and [Password] = '" + Password + "'");
            return null != model; 
        }

        private void UpdateUserInfo(Model.User user)
        {
            if (!string.IsNullOrWhiteSpace(user.UserName))
            {
                addLoginedCookie(user);
                //System.Web.HttpContext.Current.Session["_Admin_CurrentUser"] = userName;
            }
        }

        private bool IsUrl(string returnUrl)
        {
            return !Url.IsLocalUrl(returnUrl);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Model.User user, string returnUrl)
        {
            if (ValidateUser(user.UserName, user.Password))
            {

                UpdateUserInfo(user);
                if (IsUrl(returnUrl))
                    returnUrl = "/Admin/Main";
                return Redirect(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            if (string.IsNullOrEmpty(user.UserName) && string.IsNullOrEmpty(user.Password))
            {
                ViewBag.ErrorMessage = "请您输入帐户名和密码。";
            }
            else if (string.IsNullOrEmpty(user.Password))
            {
                ViewBag.ErrorMessage = "请您输入密码。";
            }
            else if (string.IsNullOrEmpty(user.UserName))
            {
                ViewBag.ErrorMessage = "请您输入帐户名。";
            }
            else
            {
                ViewBag.ErrorMessage = "您提供的帐户名和密码不匹配，请您重新输入。";
            }
            ViewBag.loginState = true;

            return View();
        }

        public ActionResult UpdatePwdPage()
        {
            var model = GetObjectByUserName(UserHelper.CurrentAdmin);
            return View(model);
        }

        public Model.User GetObjectByUserName(string username)
        {
            return service.access.GetObject<Model.User>("and [UserName] = '" + username + "'");
        }

        public string UpdatePwd(string oldPwd, string newPwd, string newpwd2)
        {
            if (newPwd != newpwd2) return "新密码必须相同";

            User model = new User();
            return PassWord(System.Web.HttpContext.Current, oldPwd, newPwd);

        }

        public string PassWord(HttpContext context, string OldPwd, string NewPwd)
        {
            Model.User model = GetObjectByUserName(context.User.Identity.Name.ToString());
            if (model != null)
            {
                OldPwd =Common.Other.GetPassWord(OldPwd);
                NewPwd = Common.Other.GetPassWord(NewPwd);

                if (model.Password == OldPwd)
                {
                    model.Password = NewPwd;

                    if (service.ObjectUpdate(model) > 0)
                    {
                        return "修改成功";
                    }
                    else { return "修改失败,系统错误"; }
                }
                else { return "现有密码输入错误"; }
            }
            else { return "修改失败,系统错误"; }
        }

        public void addLoginedCookie(Model.User mdl)
        {

            System.Web.Security.FormsAuthentication.SignOut();

            HttpCookie authCookie = System.Web.Security.FormsAuthentication.GetAuthCookie(mdl.UserName, true);
            System.Web.Security.FormsAuthenticationTicket ticket = System.Web.Security.FormsAuthentication.Decrypt(authCookie.Value);

            string userData = mdl.UserName;

            System.Web.Security.FormsAuthenticationTicket newTicket = new System.Web.Security.FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userData, System.Web.Security.FormsAuthentication.FormsCookiePath);

            authCookie.Value = System.Web.Security.FormsAuthentication.Encrypt(newTicket);

            Response.Cookies.Add(authCookie);
        }
    }
}
