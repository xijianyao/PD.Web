using PD.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PD.Web.Controllers
{
    public class MsgController : BaseController<Model.Msg>
    {

        public MsgController()
            : base(new PDService("Msg", "ID"))
        {

        }
        [HttpPost]
        public ActionResult Send(Model.Msg m)
        {
            m.ID = Common.Other.GetGuid();
            if (service.ObjectInsert(m) > 0)
                return Content("<script>alert('留言成功'); window.location.href='/Home/Index';</script>");
            else
                return Content("<script>alert('留言失败');</script>");

        }
        [HttpGet]
        public ActionResult Send()
        {
            return View();
        }
    }
}
