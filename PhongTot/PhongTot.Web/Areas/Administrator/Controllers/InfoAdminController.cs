using PhongTot.Web.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhongTot.Web.Areas.Administrator.Controllers
{
    [AuthLog(Roles = "Admin")]
    public class InfoAdminController : BaseController
    {
        // GET: Administrator/InfoAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}