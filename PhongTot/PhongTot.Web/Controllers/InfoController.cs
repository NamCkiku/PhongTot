﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhongTot.Web.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Detail(int id)
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
    }
}