using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhongTot.Web.Areas.Administrator.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Administrator/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}