using AmericaVirtual_DataModel;
using AmericaVirtual_Web.Models;
using AmericaVirtualWS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmericaVirtual_Web.Areas.Intranet.Controllers
{
    public class UserController : Controller
    {
        AmericaVirtualService America = new AmericaVirtualService();
        [Authorize(Roles = "2")]
        public ActionResult Index()
        {
            var UsersJson = America.GetUsers();
            var ListUsers = JsonConvert.DeserializeObject<List<Users>>(UsersJson);
            return View(ListUsers);
        }

        [Authorize(Roles = "1,2")]
        public ActionResult Perfil()
        {
            var UserLog = Web_Helper.GetUsuario();
            return View(UserLog);
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public ActionResult AddMod(int id = 0)
        {
            var model = new Users();
            if (id != 0)
            {
                var UsersJson = America.GetUsers(id);
                var ListUsers = JsonConvert.DeserializeObject<List<Users>>(UsersJson);
                model = ListUsers.FirstOrDefault();
            }
            return PartialView("~/Areas/Intranet/Views/User/Partial/UserAddModPartial.cshtml", model);
        }

        [Authorize(Roles = "2")]
        public ActionResult UpdateUser(Users model, bool delete = false)
        {
            var checkSend = America.AddModUser(model, delete);
            return RedirectToAction("Index", "User", new { Area = "Intranet" });
        }
    }
}