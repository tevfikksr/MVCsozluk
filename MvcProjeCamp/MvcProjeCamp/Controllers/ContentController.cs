﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeCamp.Controllers
{
    public class ContentController : Controller
    {

        ContentManager cm = new ContentManager(new EfContentDal());
     
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p="")
        {
            //var values = from x in c.Content select x;
            var values = cm.GetList(p);
            return View(values.ToList());
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cm.GetListByHeadingId(id);
            return View(contentValues);
        }
    }
}