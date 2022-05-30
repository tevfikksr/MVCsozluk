using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeCamp.Controllers
{
    public class GalleryController : Controller
    {
        ImageManager im = new ImageManager(new EfImageDal());
       
        public ActionResult Index()
        {
            var files = im.GetList();
            return View(files);
        }
    }
}