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
    public class CategoryController : BaseController<Model.Category>
    {

        public CategoryController()
            : base(new PDService("Category", "ID"))
        { 
        
        }


    }
}
