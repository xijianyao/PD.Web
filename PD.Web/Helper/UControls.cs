//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web;
//using System.Web.Mvc;
//using An.Miuskin.Model;
//using LM.Bid.Web.Helper;
//using An.Miuskin.BLL;

//namespace An.Miuskin.Web.Helper
//{
//    public static class UControls
//    {
//        private static List<Function> lstRight = new List<Function>();
//        private static string ParentId = string.Empty;
//        private static int k = 0;

//        public static MvcHtmlString GetLoginText(this HtmlHelper html, object session)
//        {
//            StringBuilder sbHtml = new StringBuilder();
//            if (null != session)
//            {
//                sbHtml.Append("<span id=\"WelcomeText\" >欢迎您：" + session.ToString() + "<b id=\"UserNickName\"></b></span>");
//                sbHtml.Append("<a href=\"/my/Portal/Index\" id=\"UserCenter\">个人中心</a>");
//                sbHtml.Append("<a href=\"/user/LogOff\" id=\"LogOff\">退出</a>");
//            }
//            else
//            {
//                sbHtml.Append("<a href=\"/User/Register\" id=\"RegisterLink\">立即注册</a>");
//                sbHtml.Append("<a href=\"/User/Login\" id=\"LoginLink\">立即登录</a>");
//            }
//            return MvcHtmlString.Create(sbHtml.ToString());
//        }

//        public static MvcHtmlString GetRQCodeImage(this HtmlHelper html)
//        {
//            StringBuilder sbHtml = new StringBuilder();
//            An.Miuskin.BLL.SettingsService sc = new BLL.SettingsService();
//            //var RQCode = sc.GetQRCodeImageList();
//            //foreach (var item in RQCode)
//            //{
//            //    sbHtml.Append("<div class=\"yqlj_two_left\">");
//            //    sbHtml.Append("<img src=\"/userfiles/RQCodeImage/"+item.Pic+"\" width=\"130\" height=\"130\" />");
//            //    sbHtml.Append("</div>");

//            //}
//            return MvcHtmlString.Create(sbHtml.ToString());
//        }


//        public static MvcHtmlString GetShowPlaceHTML(this HtmlHelper html)
//        {
//            StringBuilder sbHtml = new StringBuilder();
//            //var slist = ServiceLocator.Instance.Create<IShowPlace>().GetShowPlaceList().OrderByDescending(t => t.EndTime).Take(20).ToList();
//            //foreach (var item in slist)
//            //{
//            //    sbHtml.Append(string.Format("<option value=\"{0}\">{1}</option>",item.Id,item.Name));
//            //}
//            return MvcHtmlString.Create(sbHtml.ToString());
//        }
//        public static MvcHtmlString Memus(this HtmlHelper html)
//        {
//            var user = UserHelper.CurrentAdmin;
//            RolesService rs = new RolesService();
//            if (rs.GetRoleByUser(user).Name == "超级管理员")
//            {
//                return AllMemus();
//            }
//            StringBuilder sbHtml = new StringBuilder();
//            var rc = new An.Miuskin.BLL.FunctionService();
//            List<Function> lstTopRight = new List<Function>();
//            // 取得登陆用户名
//            //Identity user = new Identity();

//            lstRight = rc.GetMenus(user);
//            // 权限为空
//            if (lstRight == null || lstRight.Count == 0)
//            {
//                return MvcHtmlString.Create(sbHtml.ToString());
//            }

//            // 生成菜单
//            lstTopRight = lstRight.FindAll(FindTopParent);
//            foreach (Function right in lstTopRight)
//            {
//                sbHtml.Append("<div id='menu_div' title=\"").Append(right.Name).Append("\" iconCls=\"\">");
//                sbHtml.Append(GetSubRithg(right.FunctionId));
//                sbHtml.Append("</div>");
//            }
//            return MvcHtmlString.Create(sbHtml.ToString());
//        }

//        public static MvcHtmlString AllMemus()
//        {
//            StringBuilder sbHtml = new StringBuilder();
//            var rc = new An.Miuskin.BLL.FunctionService();
//            List<Function> lstTopRight = new List<Function>();
//            lstRight = rc.GetMenus();

//            // 权限为空
//            if (lstRight == null || lstRight.Count == 0)
//            {
//                return MvcHtmlString.Create(sbHtml.ToString());
//            }

//            // 生成菜单
//            lstTopRight = lstRight.FindAll(FindTopParent);
//            foreach (Function right in lstTopRight)
//            {
//                sbHtml.Append("<div id='menu_div' title=\"").Append(right.Name).Append("\" iconCls=\"\">");
//                sbHtml.Append(GetSubRithg(right.FunctionId));
//                sbHtml.Append("</div>");
//            }
//            return MvcHtmlString.Create(getSuperRight(sbHtml));
//        }


//        private static string getSuperRight(StringBuilder sb)
//        {
//            sb.Append("<div id='menu_div' title=\"").Append("超级管理员").Append("\" iconCls=\"\">");
//            sb.Append("<li class='yjca' style='border-bottom: 0px dotted rgb(0, 0, 0);'><ul class=\"layout-nav\" >");
//            sb.Append("<li id=\"").Append("userManage").Append("\"><a href=\"javascript:void(0)\" style='border-bottom:0px red solid;'>").Append("用户管理").Append("</a></li>");
//            sb.Append("<li id=\"").Append("rightManage").Append("\"><a href=\"javascript:void(0)\" style='border-bottom:0px red solid;'>").Append("功能管理").Append("</a></li>");
//            sb.Append("<li id=\"").Append("roleManage").Append("\"><a href=\"javascript:void(0)\" style='border-bottom:0px red solid;'>").Append("角色管理").Append("</a></li>");

//            sb.Append("</ul></li>");

//            sb.Append("</div>");
//            return sb.ToString();
//        }

//        /// <summary>
//        /// 取得子菜单信息
//        /// </summary>
//        /// <param name="parentId"></param>
//        /// <returns></returns>
//        private static string GetSubRithg(string parentId)
//        {
//            ParentId = parentId;
//            List<Function> lstSubRight = new List<Function>();
//            lstSubRight = lstRight.FindAll(FindSubRight);
//            StringBuilder sbSubHTML = new StringBuilder();

//            if (lstSubRight.Count > 0)
//            {
//                sbSubHTML.Append("<li class='yjca' style='border-bottom: 0px dotted rgb(0, 0, 0);'><ul class=\"layout-nav\" >");
//            }
//            foreach (Function right in lstSubRight)
//            {
//                //sbSubHTML.Append("<li><a href=\"javascript:void(0)\" onclick=\"").Append(right.RightName).Append("()\">").Append(right.RightDescription).Append("</a></li>");
//                List<Function> lstSubRight1 = new List<Function>();
//                ParentId = right.FunctionId;
//                lstSubRight1 = lstRight.FindAll(FindSubRight);

//                if (lstSubRight1.Count > 0)
//                {
//                    sbSubHTML.Append("<li onclick='Menuli(this)' class='ysgb' id=\"").Append(right.Mark).Append("\"><img style='width:15px;height:15px; float:left; margin-top:9px; margin-left:5px; ' src='/userfiles/home/plus.jpg' onclick='javascript: event.stopPropagation();MenuImg(this)' / ><a href=\"javascript:void(0)\" style='border-bottom:0px red solid; display:block; width:120px;' > ").Append(right.Name).Append("</a></li>");
//                }
//                else
//                {
//                    sbSubHTML.Append("<li id=\"").Append(right.Mark).Append("\"><a href=\"javascript:void(0)\" style='border-bottom:0px red solid;'>").Append(right.Name).Append("</a></li>");
//                }
//            }
//            if (lstSubRight.Count > 0)
//            {
//                sbSubHTML.Append("</ul></li>");
//            }
//            return sbSubHTML.ToString();
//        }

//        /// <summary>
//        /// 过滤取得顶层菜单
//        /// </summary>
//        /// <param name="right"></param>
//        /// <returns></returns>
//        private static bool FindTopParent(Function right)
//        {
//            if (right != null)
//            {

//                if (right.ParentId == null || string.Empty.Equals(right.ParentId))
//                {
//                    return true;
//                }
//                {
//                    return false;
//                }
//            }
//            return false;

//        }

//        /// <summary>
//        /// 过滤取得各层子菜单
//        /// </summary>
//        /// <param name="right"></param>
//        /// <returns></returns>
//        private static bool FindSubRight(Function right)
//        {
//            if (right != null)
//            {
//                if (ParentId.Equals(right.ParentId))
//                {

//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//            return false;
//        }

//        public static MvcHtmlString ToolbarButton(string onclick, string icon, string text)
//        {
//            if (!string.IsNullOrEmpty(icon)) { icon = "iconCls:'" + icon + "',"; }
//            return MvcHtmlString.Create("<a class=\"easyui-linkbutton\" href=\"javascript:void(0)\" onclick=\"" + onclick + "\" data-options=\"" + icon + "plain:true\">" + text + "</a>");
//        }
//    }
//}