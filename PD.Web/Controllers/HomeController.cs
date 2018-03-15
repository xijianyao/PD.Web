using PD.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// 下载于www.51aspx.com
namespace PD.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.news = new PDService("News", "ID").GetObjects<Model.News>(" and ID in (select top 4 ID from News order by InsertTime desc)");

            ViewBag.products = new PDService("Product", "ID").GetObjects<Model.Product>(" and ID in (select top 14 ID from Product order by InsertTime desc)");

            ViewBag.downloads = new PDService("Download", "ID").GetObjects<Model.Download>(" and ID in (select top 4 ID from Download order by InsertTime desc)");

            ViewBag.focus = new PDService("Focus", "ID").GetObjects<Model.Focus>("");


            ViewBag.intro = new PDService("Info", "ID").GetModel<Model.Info>("Mark","Intro");
            return View();
        }

    }
}
