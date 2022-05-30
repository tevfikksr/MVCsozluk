using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {

            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writer.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var contentValues = cm.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = c.Writer.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();

            p.WriterId = writerIdInfo;
            p.ContentStatus = true;
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
    }
}