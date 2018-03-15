using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PD.Helper
{
    public class UserHelper
    {
        static string GUEST = "guest", Admin = "admin", MY = "my";
        enum UserType
        {
            Admin = 1,
            My = 2,
            Guest = 4
        }

        public static string CurrentAdmin {
            get {
                return HttpContext.Current.User.Identity.Name;
            }
        }

        public static string CurrentUserName
        {
            get
            {
                var name = GetSessionName();
                if (string.IsNullOrEmpty(name)) return string.Empty;
                var nick = HttpContext.Current.Session[name] as string;
                return nick;
                //return "caowei20";
            }
        }

        public static string GetAreaName()
        {
            UserType uType = UserType.Guest;
            var path = HttpContext.Current.Request.Url.LocalPath.Split('/');
            if (path.Length == 1) return GUEST;

            if (path[1].ToLower().Equals(Admin)) uType = UserType.Admin;
            else if (path[1].ToLower().Equals(MY)) uType = UserType.My;

            return Enum.GetName(typeof(UserType), uType);
        }

        public static string GetSessionName()
        {
            try
            {

                string name = GetAreaName();
                if (name.ToLower().Equals(GUEST)) return string.Empty;
                else
                {
                    var sessionName = string.Format("_{0}_CurrentUser", name);
                    return sessionName;
                }
            }
            catch (Exception ex) { return string.Empty; }
        }
    }
}