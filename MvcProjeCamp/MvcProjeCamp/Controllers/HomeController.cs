using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeCamp.Controllers
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

        [AllowAnonymous]
        public ActionResult HomePage()
        {
            
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult HomeStatistics()
        {
            HeadingManager hm = new HeadingManager(new EfHeadingDal());
            ContentManager cm = new ContentManager(new EfContentDal());
            WriterManager wm = new WriterManager(new EfWriterDal());
            MessageManager mm = new MessageManager(new EfMessageDal());
            ViewBag.HeadingCount = hm.GetList().Count();
            ViewBag.EntryCount = cm.GetList().Count();
            ViewBag.WriterCount = wm.GetList().Count();
            ViewBag.MessageCount = mm.List().Count;

            return PartialView();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ContactUs(Contact c)
        {
            ContactManager cm = new ContactManager(new EfContactDal());
            c.ContactDate = DateTime.Now;
            cm.ContactAdd(c);
            return RedirectToAction("HomePage");
        }
    }
}