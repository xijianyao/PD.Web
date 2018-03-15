using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PD.Web.Helper
{
    public class BidHandleError : HandleErrorAttribute
    {
        private void HandleException(Exception ex)
        {
            try
            {
                //记录日志
                if (!System.IO.Directory.Exists(string.Format(@"{0}\Log", System.Web.HttpContext.Current.Request.PhysicalApplicationPath)))
                {
                    System.IO.Directory.CreateDirectory(string.Format(@"{0}\Log", System.Web.HttpContext.Current.Request.PhysicalApplicationPath));
                }
                DateTime now = DateTime.Now;
                string logpath = string.Format(@"{0}\Log\fatal_{1}{2}{3}.log", System.Web.HttpContext.Current.Request.PhysicalApplicationPath, now.Year, now.Month, now.Day);
                System.IO.File.AppendAllText(logpath, string.Format("\r\n----------------------{0}--------------------------\r\n", now.ToString("yyyy-MM-dd HH:mm:ss")));
                System.IO.File.AppendAllText(logpath, ex.Message);
                System.IO.File.AppendAllText(logpath, "\r\n");
                System.IO.File.AppendAllText(logpath, ex.StackTrace);
                System.IO.File.AppendAllText(logpath, "\r\n");
                System.IO.File.AppendAllText(logpath, "\r\n----------------------footer--------------------------\r\n");
            }
            catch { }

        }

        public override void OnException(ExceptionContext filterContext)
        {
            var httpContext = filterContext.RequestContext.HttpContext;

            var helper = new UrlHelper(filterContext.RequestContext);

            try
            {
                HandleException(filterContext.Exception);
                //记录日志到DB
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
            }
        }
    }
}