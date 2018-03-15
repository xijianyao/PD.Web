using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PD.Web.Controllers
{
    public class UploadImgController : Controller
    {
        //
        // GET: /UploadImg/
        public HttpContext context = System.Web.HttpContext.Current;

        [HttpPost]
        public ActionResult uploadID(HttpPostedFileBase head)
        {
            try
            {
                if ((head == null))
                {
                    return Json(new { msg = 0 });
                }
                else
                {
                    String dirPath = context.Server.MapPath("~/userfiles/");
                    var supportedTypes = new[] { "jpg", "jpeg", "png", "gif", "bmp" };
                    var fileExt = System.IO.Path.GetExtension(head.FileName).Substring(1);
                    if (!supportedTypes.Contains(fileExt))
                    {
                        return Json(new { msg = -1 });
                    }

                    if (head.ContentLength > 1024 * 1000 * 10)
                    {
                        return Json(new { msg = -2 });
                    }
                    var filename = Common.Other.GetGuid() + "." + fileExt;
                    dirPath += "Agency/";
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    var filepath = Path.Combine(dirPath, filename);
                    try
                    {
                        System.IO.File.Delete(filepath);
                    }
                    catch
                    {

                    }
                    head.SaveAs(filepath);
                    return Content("<script>window.parent.uploadSuccess('上传成功|" + filename + "');</script>");
                }
            }
            catch (Exception)
            {
                return Content("<script>window.parent.uploadSuccess('failed" + "');</script>");
            }
        }


        public void UploadFile()
        {
            //文件保存目录URL
            String saveUrl = "/userfiles/";

            //文件保存目录路径
            String dirPath = context.Server.MapPath("~/userfiles/");
            string dir = "file";
            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add(dir, "doc,docx,xls,xlsx,ppt,pptx,txt,pdf");

            //最大文件大小
            int maxSize = 25000000;

            HttpPostedFile imgFile = context.Request.Files["imgFile"];

            if (imgFile == null) { showError("请选择文件。"); }

            if (!Directory.Exists(dirPath)) { showError("上传目录不存在。"); }

            String dirName = dir;

            String fileName = imgFile.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();

            if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
            {
                showError("上传文件大小超过限制。");
            }

            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
            }
            
            //创建文件夹
            dirPath += dirName + "/";
            saveUrl += dirName + "/";

            if (!Directory.Exists(dirPath)) { Directory.CreateDirectory(dirPath); }

            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;

            String filePath = dirPath + newFileName;

            String tempPath = context.Server.MapPath("~/temp/" + Common.Other.GetGuid() + fileExt);

            imgFile.SaveAs(tempPath);
            System.IO.File.Delete(tempPath);
            imgFile.SaveAs(filePath);
            String fileUrl = saveUrl + newFileName;
            Hashtable hash = new Hashtable();
            hash["error"] = 0;
            hash["url"] = newFileName;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(hash));
            context.Response.End();
        }

        public void Upload(string dir, int width = 230,int height=144)
        {
            //文件保存目录URL
            String saveUrl = "/userfiles/";

            //文件保存目录路径
            String dirPath = context.Server.MapPath("~/userfiles/");

            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add(dir, "gif,jpg,jpeg,png,bmp");

            //最大文件大小
            int maxSize = 5000000;

            HttpPostedFile imgFile = context.Request.Files["imgFile"];

            if (imgFile == null) { showError("请选择文件。"); }

            if (!Directory.Exists(dirPath)) { showError("上传目录不存在。"); }

            String dirName = dir;

            String fileName = imgFile.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();

            if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
            {
                showError("上传文件大小超过限制。");
            }

            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
            }
            
            //创建文件夹
            dirPath += dirName + "/";
            saveUrl += dirName + "/";

            if (!Directory.Exists(dirPath)) { Directory.CreateDirectory(dirPath); }

            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;

            String filePath = dirPath + newFileName;

            String tempPath = context.Server.MapPath("~/temp/" + Common.Other.GetGuid() + fileExt);

            imgFile.SaveAs(tempPath);
            
            string DepartmentId = context.Request.QueryString["DepartmentId"];

            if (width != 230 || height != 144)
            {
                Common.ThumNail.MakeThumNail(tempPath, filePath, width, height, "Cut");
            }
            else
            {
                System.IO.File.Delete(tempPath);
                imgFile.SaveAs(filePath);
            }
            String fileUrl = saveUrl + newFileName;
            Hashtable hash = new Hashtable();
            hash["error"] = 0;
            hash["url"] = newFileName;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(hash));
            context.Response.End();
        }

        public void UploadZZ(string dir, int width = 91, int height = 60)
        {
            //文件保存目录URL
            String saveUrl = "/userfiles/";

            //文件保存目录路径
            String dirPath = context.Server.MapPath("~/userfiles/");

            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add(dir, "gif,jpg,jpeg,png,bmp");

            //最大文件大小
            int maxSize = 5000000;

            HttpPostedFile imgFile = context.Request.Files["FileData"];

            if (imgFile == null) { showError("请选择文件。"); }

            if (!Directory.Exists(dirPath)) { showError("上传目录不存在。"); }

            String dirName = dir;

            String fileName = imgFile.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();

            if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
            {
                showError("上传文件大小超过限制。");
            }

            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
            }

            //创建文件夹
            dirPath += dirName + "/";
            saveUrl += dirName + "/";

            if (!Directory.Exists(dirPath)) { Directory.CreateDirectory(dirPath); }

            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;

            String filePath = dirPath + newFileName;

            String tempPath = context.Server.MapPath("~/temp/" + Common.Other.GetGuid() + fileExt);

            imgFile.SaveAs(tempPath);

            string DepartmentId = context.Request.QueryString["DepartmentId"];

            if (width != 230 || height != 144)
            {
                Common.ThumNail.MakeThumNail(tempPath, filePath, width, height, "Cut");
            }
            else
            {
                System.IO.File.Delete(tempPath);
                imgFile.SaveAs(filePath);
            }
            String fileUrl = saveUrl + newFileName;
            Hashtable hash = new Hashtable();
            hash["error"] = 0;
            hash["url"] = newFileName;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(hash));
            context.Response.End();
        }

        public void showError(string message)
        {
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = message;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(hash));
            context.Response.End();
        }

    }
}
