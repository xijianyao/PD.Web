using PD.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PD.Web.Controllers
{
    public class FocusController : BaseController<Model.Focus>
    {

        public FocusController()
            : base(new PDService("Focus", "ID"))
        { 
        
        }


    }
}
