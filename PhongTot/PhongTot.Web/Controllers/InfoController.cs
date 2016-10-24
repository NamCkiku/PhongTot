using PhongTot.Web.Models;
using System;
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
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
                
        }
        public ActionResult Detail(int id)
        {
            return View();
        }
        public ActionResult Search(InfoSearchModel filterParams)
        {
            return View();
        }
    }
}