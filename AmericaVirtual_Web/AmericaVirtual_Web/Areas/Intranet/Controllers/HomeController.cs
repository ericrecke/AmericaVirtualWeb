using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmericaVirtual_Web.Areas.Intranet.Controllers
{
    public class HomeController : Controller
    {
        // GET: Intranet/Home
        [Authorize(Roles = "2")]
        public ActionResult Index()
        {
            return View();
        }
    }
}