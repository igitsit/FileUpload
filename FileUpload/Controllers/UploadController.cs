using System;  
using System.Collections.Generic;  
using System.IO;  
using System.Linq;  
using System.Web;  
using System.Web.Mvc;
using FileUpload.Models;
namespace FileUpload.Controllers  
{  
    public class UploadController : Controller
{
    // GET: Upload  
    public ActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public ActionResult UploadFile()
    {
        return View();
    }
    [HttpPost]
    public ActionResult UploadFile(Image Img,  HttpPostedFileBase file )
    {
        try
        {  //kjdshfkjdshf

            Image imageModel = new Image();
            
            if (file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                imageModel.ImagePath = _path;
                imageModel.FileName = _FileName;
                imageModel.Title = Img.Title;
                file.SaveAs(_path);
                
            }
                using (ImageEntities db = new ImageEntities())
                {   
                    db.Images.Add(imageModel);
                    db.SaveChanges();
                }
                    ViewBag.Message = "File Uploaded Successfully!!";
                     return View();
        }
        catch
        {
            ViewBag.Message = "File upload failed!!";
            return View();
        }
    }
}  
}  