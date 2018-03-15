using System;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using System.Collections.Generic;
using System.Web.Mvc.Html;

namespace An.Miuskin.Web.Helper
{
    public static class PagingHelpers
    {
        //public static MvcHtmlString PageLinks(this HtmlHelper html,
        //PagingInfo pagingInfo,
        //Func<int, string> pageUrl)
        //{
        //    StringBuilder result = new StringBuilder();
        //    for (int i = 1; i <= pagingInfo.TotalPages; i++)
        //    {
        //        TagBuilder tag = new TagBuilder("a");    //创建<a>标签
        //        tag.MergeAttribute("href", pageUrl(i));
        //        tag.InnerHtml = i.ToString();
        //        if (i == pagingInfo.CurrentPage) tag.AddCssClass("selected");
        //        result.Append(tag.ToString());
        //    }
        //    return MvcHtmlString.Create(result.ToString());
        //}
    }
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}