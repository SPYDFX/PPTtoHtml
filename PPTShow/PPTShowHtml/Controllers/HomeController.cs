using PPTShowHtml.Common;
using PPTShowHtml.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPTShowHtml.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UpdateImage()
        {
            return View();
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadFile()
        {
            Result<string> check = new Result<string>();
            try
            {
                var files = System.Web.HttpContext.Current.Request.Files;
               // var files = System.Web.HttpContext.Current.Request;
                if (files.Count==0)
                {
                    check.msg = "请选择要上传的图片！";
                    check.success = false;
                    return Json(check);
                }
                //var imgpath = System.Web.HttpContext.Current.Request["path"].ToString();
                string HtmlName = DateTime.Now.ToString("yyyyMMddHHmmss");
                var imgpath = DateTime.Now.ToString("yyyyMMdd") +"\\"+ HtmlName;
                int number = 0;
                List<Stream> streams = new List<Stream>();
               // Dictionary<string, Stream> filedic = new Dictionary<string, Stream>();
                var path = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + imgpath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                for (int i = 0; i < files.Count; i++)
                {
                    var fileName = path + "\\" + files[i].FileName;
                    files[i].SaveAs(fileName);
                    bool ok = System.IO.File.Exists(fileName.ToString());
                    if (ok)
                    {
                        number++;
                    }
                }
                if (number.Equals(files.Count))
                {
                    check.msg = "上传成功！";
                    check.success = true;
                    var re= Office2HtmlHelper.writeHtml(path, HtmlName);
                    if(!string.IsNullOrWhiteSpace(re))
                    {
                        check.data = path +"\\"+ re;
                    }  
                }
                else
                {
                    check.msg = "失败！";
                    check.success = false;
                }
                return Json(check);
            }
            catch (Exception ex)
            {
                check.msg = ex.ToString();
                check.success = false;
                return Json(check);
            }
        }
    }
}