using PD.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PD.Web.Controllers
{
    public class SettingController : BaseController<Model.Setting>
    {
        //
        // GET: /Setting/
                public SettingController()
            : base(new PDService("Setting", "ID"))
        {
            // 下载于www.51aspx.com
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact(string ID)
        {
            var dt = getSetting();
            ViewBag.dt = dt;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public string SettingModel(string SystemName, string SiteName, string Keywords, string Description, string Phone, string Mobile, string Email, string Address, string Copyright,string Person,string Deliver,string QQ, string gltd,string Zizi,string KFQQ)
        {
            update(SystemName, "SystemName");
            update(SiteName, "SiteName");
            update(Keywords, "Keywords");
            update(Description, "Description");
            update(Phone, "Phone");
            update(Mobile, "Mobile");
            update(Email, "Email");
            update(Person, "Person");
            update(Deliver, "Deliver");
            update(QQ, "QQ");
            update(KFQQ, "KFQQ");

            update(Address, "Address");
            update(Copyright, "Copyright");
            update(gltd, "gltd");
            Zizi=Zizi.TrimEnd(',');
            //Zizi=Zizi.Remove(0,1);
            update(Zizi, "gltd");
            return "{$Update}";
        }


        public ActionResult Setting()
        {
            DataTable dt = getSetting();
            ViewBag.dt = dt;
            return View();
        }

        public void update(string C, string M)
        {
            string sql = "update Setting set Content='" + C + "' where Mark='" + M + "'";
            Access.Access.ExecuteNonQuery(sql);
        }

        public Model.Setting GetObjectByMark(string mark)
        {
            return service.GetObject<Model.Setting>("and [Mark] = '" + mark + "'");
        }

        public int GetCountByMark(string mark)
        {
            return service.ObjectCount("and [Mark] = '" + mark + "'");
        }

        public string Model(HttpContext context)
        {
            SetSetting(context, "SystemName");
            SetSetting(context, "SiteName");
            SetSetting(context, "Keywords");
            SetSetting(context, "Description");
            SetSetting(context, "SiteKey");
            SetSetting(context, "Copyright");
            SetSetting(context, "Tel");
            SetSetting(context, "WorkTime");
            return "{$Update}";
        }

        public void SetSetting(HttpContext context, string mark)
        {
            if (GetCountByMark(mark) > 0)
            {
                Model.Setting model = GetObjectByMark(mark);

                model.Content = context.Request.Form[mark];

                service.ObjectUpdate(model);
            }
            else
            {
                Model.Setting model = new Model.Setting();

                model.ID = Common.Other.GetGuid();
                model.Mark = mark;
                model.Content = context.Request.Form[mark];

                service.ObjectInsert(model);
            }
        }

        public DataTable getSetting()
        {
            string sql = "select *from Setting";
            DataTable dt = Access.Access.ReturnTableQuery(sql);
            return dt;
        }

        
    }
}
