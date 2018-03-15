using System;
using System.Text;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Security.Principal;

namespace Ankj.Game.Controls
{
    public class Menus : WebControl
    {
        protected override void Render(HtmlTextWriter wt)
        {
            //wt.Write(CreateHtml());
        }

        public string CreateHtml()
        {
        //    Controller.PluginsController pl = new Controller.PluginsController();
        //    Controller.RolesController ro = new Controller.RolesController();
        //    StringBuilder sb = new StringBuilder();

        //    List<Model.Plugins> list = pl.GetObjectsByParentId("and [Type] != 'Functions'", string.Empty);
         //   Model.Roles role = ro.GetObject<Model.Roles>(Common.Other.GetRoleId(Page.User));

        //    string _tempicon = "<style type=\"text/css\">";

        //    foreach (Model.Plugins model in list)
        //    {
        //        int count = 0; string _temp = string.Empty;

        //        if ((role.Functions.Contains(model.PluginId) && model.Enabled) || role.Code == "Administrator")
        //        {
        //            if (string.IsNullOrEmpty(model.Icon))
        //            {
        //                _temp += "<div title=\"" + model.Name + "\"\">";
        //            }
        //            else
        //            {
        //                _temp += "<div title=\"" + model.Name + "\" iconCls=\"icon_" + model.PluginId + "\">";
        //                _tempicon += ".icon_" + model.PluginId + " { background:url('../public/icons/" + model.Icon + "') no-repeat; }";
        //            }

        //            _temp += "<ul class=\"layout-nav\">";

        //            foreach (Model.Plugins item in pl.GetObjectsByParentId("and [Type] != 'Functions'", model.PluginId))
        //            {
        //                if ((role.Functions.Contains(item.PluginId) && item.Enabled) || role.Code == "Administrator")
        //                {
        //                    switch (item.Type)
        //                    {
        //                        case "Tabs":
        //                            _temp += "<li><a href=\"javascript:void(0)\" onclick=\"AddTab('" + item.Name + "','tables/" + item.Path + "/" + item.File + "')\">" + item.Name + "</a></li>";
        //                            break;
        //                        case "Dialog":
        //                            _temp += "<li><a href=\"javascript:void(0)\" onclick=\"AddDialog('tables/" + item.Path + "/" + item.File + "')\">" + item.Name + "</a></li>";
        //                            break;
        //                        case "Null":
        //                            _temp += "<li><a href=\"javascript:void(0)\">" + item.Name + "</a></li>";
        //                            break;
        //                    }
        //                    count++;
        //                }
        //            }

        //        }

        //        if (count > 0) { sb.Append(_temp + "</ul></div>"); }
        //    }

           // return sb.ToString() + _tempicon + "</style>";
            return "";
        }
    }
}
