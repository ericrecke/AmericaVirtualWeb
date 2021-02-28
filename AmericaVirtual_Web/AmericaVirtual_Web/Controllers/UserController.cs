using AmericaVirtual_DataModel;
using AmericaVirtualWS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AmericaVirtual_DataModel.Manager;
using static AmericaVirtual_DataModel.Manager.Base_Manager;
using AmericaVirtual_Web.Models;

namespace AmericaVirtual_Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Usuario, string Password)
        {
            AmericaVirtualService America = new AmericaVirtualService();
            string TryLogin = America.ValidateLogin(Usuario, Password);
            if (TryLogin != "")
            {
                var UserInfo = JsonConvert.DeserializeObject<Users>(TryLogin);
                Web_Helper.SetFormsAuthenticationClientTicket(UserInfo, new string[] { UserInfo.UserType.ToString() },true, UserInfo.Email);
                //FormsAuthentication.SetAuthCookie(UserInfo.Name, false);
                if (UserInfo.UserType == EnumTypeUser.Admin)
                    return RedirectToAction("Index", "Home", new { Area = "Intranet" });
                else
                    return RedirectToAction("Index", "Home", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

    }
}