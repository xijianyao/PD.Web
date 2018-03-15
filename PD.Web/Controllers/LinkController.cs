using PD.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PD.Web.Controllers
{
    public class LinkController: BaseController<Model.Link>
    {

        public LinkController()
            : base(new PDService("Link", "ID"))
        {
            // 下载于www.51aspx.com
        }


    }
}
