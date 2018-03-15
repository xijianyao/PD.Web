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
    public class ProductController : BaseController<Model.Product>
    {

        public ProductController()
            : base(new PDService("Product", "ID"))
        { 
        
        }

        public ActionResult List(string cat,int pg=1) {

            StringBuilder where = new StringBuilder();
            if (!string.IsNullOrEmpty(cat))
            {
                where.Append(" and CategoryId='" + cat + "'");
                ViewBag.cat = new Access.Server("Category", "ID").GetObject<Model.Category>(" and ID='"+cat+"'");
            }
            int count = 0;
            ViewBag.products = service.GetObjects<Model.Product>(12, pg, where.ToString(), "InsertTime", 1, ref count);



            PagingInfo p = new PagingInfo();
            p.CurrentPage = pg;
            p.ItemsPerPage = 12;
            p.TotalItems =service.ObjectCount(where.ToString());
            ViewBag.PageInfo = p;

            return View();
        }

        public ActionResult Detail(string ID)
        {
            var p = service.GetModel<Model.Product>("ID",ID);
            p.ReadTimes = p.ReadTimes==null?0:p.ReadTimes + 1;
            service.ObjectUpdate(p);
            return View(p);
        }
    }
}
