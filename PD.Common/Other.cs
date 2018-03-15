using System;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

namespace PD.Common
{
    public static class Other
    {
        private static long code;
        /// <summary>
        /// 获取32位随机编号
        /// </summary>
        /// <returns>随机编号</returns>
        public static string GetGuid()
        {
            string guid = Guid.NewGuid().ToString();

            return guid.Replace("-", string.Empty);
        }

        /// <summary>
        /// 获取32位随机编号
        /// </summary>
        /// <returns>随机编号</returns>
        public static Guid GetObjGuid()
        {
            return Guid.NewGuid();
        }

        ///
        ///
        ///
        ///
        public static string getDJBH()
        {
            //return "DL" + DateTime.Now.ToString("yyMMdd");

            code++;
            String str = DateTime.Now.ToString("yyMMdd").ToString();
            long m = long.Parse(str) * 10000;
            m += code;
            return "DL" + m;
        }


        /// <summary>
        /// 获取加密后的密码
        /// </summary>
        /// <param name="input">加密前的密码</param>
        /// <returns>加密后的密码</returns>
        public static string GetPassWord(string input)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(input, "MD5");
        }

        /// <summary>
        /// 获取指定长度文本
        /// </summary>
        /// <param name="value">原文本</param>
        /// <param name="length">指定长度</param>
        /// <returns>截取后文本</returns>
        public static string CutString(string value, int length)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);

            StringBuilder sb = new StringBuilder();
            char[] stringChar = value.ToCharArray();

            int nLength = 0; bool isCut = false;

            for (int i = 0; i < stringChar.Length; i++)
            {
                if (regex.IsMatch((stringChar[i]).ToString()))
                {
                    sb.Append(stringChar[i]); nLength += 2;
                }
                else
                {
                    sb.Append(stringChar[i]); nLength += 1;
                }

                if (nLength > length) { isCut = true; break; }
            }

            if (isCut) { return sb.ToString() + "..."; } else { return sb.ToString(); }
        }

        /// <summary>
        /// 获取文本的实际长度
        /// </summary>
        /// <param name="value">文本代码</param>
        /// <returns>占用长度</returns>
        public static int GetLength(string value)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);

            int nLength = 0; char[] stringChar = value.ToCharArray();

            for (int i = 0; i < stringChar.Length; i++)
            {
                if (regex.IsMatch((stringChar[i]).ToString()))
                {
                    nLength += 2;
                }
                else { nLength += 1; }
            }

            return nLength;
        }

        /// <summary>
        /// 执行脚本
        /// </summary>
        /// <param name="script">脚本内容</param>
        /// <param name="p">要执行的页面</param>
        public static void Script(string script, System.Web.UI.Page p)
        {
            script = "<script language='javascript'>" + script + "</script>";
            p.ClientScript.RegisterStartupScript(script.GetType(), "script", script);
        }

        /// <summary>
        /// 删除所有HTML标签
        /// </summary>
        /// <param name="html">HTML</param>
        /// <returns>清理后的字符串</returns>
        public static string NoHTML(string html)
        {
            //删除脚本
            if (html == null)
            {
                html = string.Empty;
            }
            html = Regex.Replace(html, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML  
            html = Regex.Replace(html, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"-->", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<!--.*", "", RegexOptions.IgnoreCase);

            html = Regex.Replace(html, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            html.Replace("<", "");
            html.Replace(">", "");
            html.Replace("\r\n", "");
            html = HttpContext.Current.Server.HtmlEncode(html).Trim();

            return html;
        }
        /// <summary>
        /// 根据HttpContext获取用户角色
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <returns>RoleId</returns>
        public static string GetRoleId(IPrincipal user)
        {
            FormsIdentity identity = user.Identity as FormsIdentity;

            return identity.Ticket.UserData.Split(',')[1];
        }
    }
}
