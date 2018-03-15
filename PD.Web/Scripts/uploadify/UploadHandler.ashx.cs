using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PD.Web.Scripts.uploadify
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //http://www.cnblogs.com/babycool/
            //接收上传后的文件
            HttpPostedFile file = context.Request.Files["Filedata"];
            //其他参数
            //string somekey = context.Request["someKey"];
            //string other = context.Request["someOtherKey"];
            //获取文件的保存路径
            string uploadPath =
                HttpContext.Current.Server.MapPath("~/userfiles/zz" + "\\");
            //判断上传的文件是否为空
            if (file != null)
            {
                try
                {
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    //保存文件
                    Random r = new Random();
                    string filename = System.DateTime.Now.ToString("yyMMddhhmmss"+r.Next(9)+r.Next(9)+r.Next(9))+"." + file.FileName.Split('.')[1];
                    file.SaveAs(uploadPath + filename);
                    context.Response.Write(filename);
                }
                catch(Exception e) {
                    context.Response.Write("error:"+e.InnerException);
                
                }
                
            }
            else
            {
                context.Response.Write("error");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}