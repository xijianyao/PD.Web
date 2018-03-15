using PD.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PD.Web.Controllers
{
    public class InfoController : BaseController<Model.Info>
    {

        public InfoController()
            : base(new PDService("Info", "ID"))
        { 
        
        }

        public ActionResult Detail(string ID)
        {
            ViewBag.infos = new PDService("Info", "ID").GetModels<Model.Info>("");

            var p = service.GetModel<Model.Info>("ID", ID);
            return View(p);
        }
        public ActionResult Support(string ID)
        {
            ViewBag.infos = new PDService("Info", "ID").GetModels<Model.Info>("");

            var p = service.GetModel<Model.Info>("ID", ID);
            return View(p);
        }
        public ActionResult Job(string ID)
        {
            ViewBag.infos = new PDService("Info", "ID").GetModels<Model.Info>("");

            var p = service.GetModel<Model.Info>("ID", ID);
            return View(p);
        }
    }
}
