using PD.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Dapper;
using DapperExtensions;
using PD.Web.Helper;
namespace PD.Web.Controllers
{
    public class BaseController<M> : Controller where M : class, new()
    {
        public CommonService service;
        //
        // GET: /Base/
        public BaseController(CommonService service)
        {
            this.service = service;
        }
        // 下载于www.51aspx.com
        [AllowAnonymous]
        public string DataGridJson()
        {
            int page = Convert.ToInt32(Request.Params.Get("page"));
            int rows = Convert.ToInt32(Request.Params.Get("rows"));
            if (page == 0)
            {
                page = 1;
            }
            if (rows == 0)
            {
                rows = 20;
            }
            int recordcount = 0;
            string order = "ID";

            List<M> list = new List<M>();
            list = service.GetObjects<M>(rows, page, "", order, service.GetOrderType(order), ref recordcount);
            List<string> fields = new List<string>();
            typeof(M).GetProperties().ToList().ForEach(t => fields.Add(t.Name));
            return JsonTransform.SerializeObject<M>(list, typeof(M).Name, fields.ToArray(), new List<JsonMapTable>(), recordcount);

        }

        [HttpGet]
        public virtual ActionResult Edit(string ID = "")
        {

            if (string.IsNullOrEmpty(ID))
                return View(new M());
            else
            {
                var model = service.GetObject<M>(ID);
                return View(model);
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public virtual string Edit(M p)
        {
            Type t = p.GetType();
            var propertyInfo = t.GetProperty("ID");
            if (propertyInfo == null)
            {
                return "操作失败";
            }

            string ID = propertyInfo.GetValue(p, null) == null ? "" : propertyInfo.GetValue(p, null).ToString();

            Type type = p.GetType();
            // Iterate through all the methods of the class.
            foreach (var mInfo in type.GetProperties())
            {
                // Iterate through all the Attributes for each method.
                foreach (Attribute attr in
                    Attribute.GetCustomAttributes(mInfo))
                {
                    // Check for the AnimalType attribute.
                    if (attr.GetType() == typeof(Model.CurrentUserAttribute))
                        mInfo.SetValue(p, System.Web.HttpContext.Current.User.Identity.Name, null);
                }

            }

            if (string.IsNullOrEmpty(ID))
            {

                propertyInfo.SetValue(p, Common.Other.GetGuid(), null);
                using (var con = this.OpenConnection())
                {
                    try
                    {
                        con.Insert(p);
                        return "{$Insert}";
                    }
                    catch { return "操作失败"; }
                }
            }
            else
            {
                using (var con = this.OpenConnection())
                {
                    if (con.Update(p)) { return "{$Update}"; } else { return "操作失败"; }
                }
            }
        }

        public string Delete(string ID)
        {
            string[] id = ID.Split(',');
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = id[i].Replace('\'', '\0');
                service.ObjectDelete(id[i]);
            }
            return "删除成功";
        }

        public virtual ActionResult Index()
        {
            //var prof = service.GetModels<M>("");
            return View();
        }

    }
}
