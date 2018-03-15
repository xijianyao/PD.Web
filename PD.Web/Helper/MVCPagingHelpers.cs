using An.Miuskin.Web.Helper;
using PD.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class MVCPagingHelpers
    {
        /// <summary>
        /// 上图分页右边的 页数信息
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pagingInfo"></param>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks(this System.Web.Mvc.HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            //新建StringBuilder实例result       将他作为最终的html字符串生成相应的标签 
            StringBuilder result = new StringBuilder();

            if (pagingInfo.TotalPages != 0)
            {
                //首页 前页
                TagBuilder tagFirst = new TagBuilder("a");
                //a标签的值
                tagFirst.InnerHtml = "«";
                TagBuilder tagPrior = new TagBuilder("a");
                tagPrior.InnerHtml = "‹";
                //如果当前页不是第一页，那么首页和前页应该是可以点击的，同理 后页和尾页就不注释了
                if (pagingInfo.CurrentPage != 1)
                {
                    tagFirst.MergeAttribute("href", pageUrl(1));
                    tagPrior.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 1));
                }
                else {
                    tagFirst.MergeAttribute("class", "Nobefore");
                }
                //将标签tostring后 追加到StringBuilder
                result.Append(tagFirst.ToString());
                result.Append(tagPrior.ToString());

                //页数
                //这里只显示当前页的 前后3页
                for (int i = pagingInfo.CurrentPage - 3; i <= pagingInfo.CurrentPage + 3; i++)
                {
                    //不允许生成 小于1 或大于总页数的  a标签
                    if (i > 0 && i <= pagingInfo.TotalPages)
                    {
                        //使用TagBuilder创建a标签
                        TagBuilder tag = new TagBuilder("a");
                        //当前a标签的跳转地址
                        if (i != pagingInfo.CurrentPage)
                            tag.MergeAttribute("href", pageUrl(i));

                        if (i == pagingInfo.CurrentPage)
                            tag.MergeAttribute("class", "cpb");
                        //以数字代表a标签的显示内容
                        tag.InnerHtml = i.ToString();

                        result.Append(tag.ToString());
                    }
                }
                //后页 尾页
                TagBuilder tagAfter = new TagBuilder("a");
                tagAfter.InnerHtml = "›";
                TagBuilder tagEnd = new TagBuilder("a");
                tagEnd.InnerHtml = "»";
                if (pagingInfo.CurrentPage != pagingInfo.TotalPages)
                {
                    tagAfter.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage + 1));
                    tagEnd.MergeAttribute("href", pageUrl(pagingInfo.TotalPages));
                }
                result.Append(tagAfter.ToString());
                result.Append(tagEnd.ToString());
            }

            //创建html标签 返回！！！
            return MvcHtmlString.Create(result.ToString());
        }
        /// <summary>
        /// 上图分页左边的 页面信息显示
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pagingInfo"></param>
        /// <returns></returns>
        public static MvcHtmlString PageShow(this System.Web.Mvc.HtmlHelper html, PagingInfo pagingInfo)
        {
            //新建StringBuilder实例result 将他作为最终的html字符串 生成相应的 标签 
            StringBuilder result = new StringBuilder();
            if (pagingInfo.TotalPages != 0)
            {
                result.Append("<font color='#ff6600'><b>" + pagingInfo.CurrentPage + "</b></font> / " + pagingInfo.TotalPages + " 页，每页<font color='#ff6600'><b>" + pagingInfo.ItemsPerPage + "</b></font> 条，共 <font color='#ff6600'><b>" + pagingInfo.TotalItems + "</b></font> 条");
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}