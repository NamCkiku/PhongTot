using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhongTot.Web.Areas.Administrator.Controllers
{
    public class PostAdminController : Controller
    {
        // GET: Administrator/PostAdmin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
    }
}