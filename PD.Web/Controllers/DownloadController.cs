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
    public class DownloadController : BaseController<Model.Download>
    {

        public DownloadController()
            : base(new PDService("Download", "ID"))
        {
            // 下载于www.51aspx.com
        }

        public ActionResult Detail(string ID)
        {

            var p = service.GetModel<Model.Download>("ID", ID);
            p.Times = p.Times == null ? 0 : p.Times + 1;
            service.ObjectUpdate(p);
            return View(p);
        }


        public ActionResult List(int? Type, int pg = 1)
        {
            StringBuilder where = new StringBuilder();
            if (null != Type)
                where.Append(" and Type=" + Type);

            int count = 0;
            ViewBag.download = service.GetObjects<Model.Download>(20, pg, where.ToString(), "InsertTime", 1, ref count);



            PagingInfo p = new PagingInfo();
            p.CurrentPage = pg;
            p.ItemsPerPage = 20;
            p.TotalItems = service.ObjectCount(where.ToString());
            ViewBag.PageInfo = p;


            return View();
        }
    }
}
