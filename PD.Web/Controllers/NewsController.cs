using An.Miuskin.Web.Helper;
using PD.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PD.Web.Controllers
{
    public class NewsController : BaseController<Model.News>
    {

        public NewsController()
            : base(new PDService("News", "ID"))
        { 
        
        }
        public ActionResult Detail(string ID)
        {

            var p = service.GetModel<Model.News>("ID", ID);
            var u = new PDService("User", "ID").GetModel<Model.User>("UserName", p.UID);
            ViewBag.user = u;
            return View(p);
        }


        public ActionResult List(int? Type,int pg=1)
        {
            StringBuilder where = new StringBuilder();
            if (null != Type)
                where.Append(" and Type="+Type);

            int count = 0;
            ViewBag.news = service.GetObjects<Model.News>(20, pg, where.ToString(), "InsertTime", 1, ref count);



            PagingInfo p = new PagingInfo();
            p.CurrentPage = pg;
            p.ItemsPerPage = 20;
            p.TotalItems = service.ObjectCount(where.ToString());
            ViewBag.PageInfo = p;


            return View();
        }


    }
}
