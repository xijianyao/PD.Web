using PD.Web.Helper;
using System.Web;
using System.Web.Mvc;

namespace PD.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new BidHandleError());
            filters.Add(new HandleErrorAttribute());
        }
    }
}