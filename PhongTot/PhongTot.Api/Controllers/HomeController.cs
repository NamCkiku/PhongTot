using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhongTot.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            int counta = Request.Files.Count;
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];
                fName = file.FileName;
                var fileName1 = Path.GetFileName(file.FileName);
                if (file != null && file.ContentLength > 0)
                {
                    //model.fileUpload.Add(file);
                    if (Session["fileUpload"] == null)
                    {
                        fileUpload.Add(file);

                    }
                    else
                    {
                        fileUpload = (List<HttpPostedFileBase>)Session["fileUpload"];
                        fileUpload.Add(file);

                    }
                }
            }
            Session["fileUpload"] = fileUpload;


            if (isSavedSuccessfully)
            {
                return Json(new { Message = fName });
            }
            else
            {
                return Json(new { Message = "Error in saving file" });
            }
        }
        public List<HttpPostedFileBase> fileUpload = new List<HttpPostedFileBase>();
        [HttpPost]
        public ActionResult DeleteFile(string id)
        {

            fileUpload = (List<HttpPostedFileBase>)Session["fileUpload"];

            //Session["fileUpload"] = null;
            bool isSavedSuccessfully = true;
            string fName = "";
            foreach (var file in fileUpload)
            {
                if (file.FileName == id)
                {
                    fileUpload.Remove(file);
                    break;
                }
            }
            Session["fileUpload"] = fileUpload;
            if (isSavedSuccessfully)
            {
                return Json(new { Message = fName });
            }
            else
            {
                return Json(new { Message = "Error in delete file" });
            }
        }
    }
}
