using DataAccessLayer.Concrete;
using MvcProjeCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeCamp.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryPie()
        {
            return View();
        }

        public ActionResult WriterPie()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }


        public List<Categories> BlogList()
        {
            List<Categories> ct = new List<Categories>();
            ct.Add(new Categories()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new Categories()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new Categories()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 5
            });
            ct.Add(new Categories()
            {
                CategoryName = "Spor",
                CategoryCount = 7
            });
            return ct;
        }

        public List<CategoryChart> CategoryList()
        {
            List<CategoryChart> categoryCharts = new List<CategoryChart>();
            using (var context = new Context())
            {
                categoryCharts = context.Categories.Select(c => new CategoryChart
                {
                    CategoryName = c.CategoryName,
                    CategoryCount = c.Headings.Count()
                }).ToList();
            }
            return categoryCharts;
        }

        public ActionResult CategoryCharts()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public List<WriterChart> WriterList()
        {
            List<WriterChart> writerCharts = new List<WriterChart>();
            using (var context = new Context())
            {
                writerCharts = context.Writer.Select(c => new WriterChart
                {
                    WriterName = c.WriterName,
                    WriterCount = c.Headings.Count()
                }).ToList();
            }
                return writerCharts;
        }

        public ActionResult WriterCharts()
        {
            return Json(WriterList(),JsonRequestBehavior.AllowGet);
        }
    }
}