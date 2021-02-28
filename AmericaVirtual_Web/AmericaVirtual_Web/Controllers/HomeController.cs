using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AmericaVirtual_DataModel;
using AmericaVirtual_Web.Models;
using AmericaVirtualWS;
using Newtonsoft.Json;

namespace AmericaVirtual_Web.Controllers
{
    public class HomeController : Controller
    {
        AmericaVirtualService America = new AmericaVirtualService();
        public ActionResult Index()
        {
            BaseModel model = new BaseModel();
            if (User.Identity.IsAuthenticated)
            {
                var Paises = America.GetCountries();
                model.Paises = JsonConvert.DeserializeObject<List<Countries>>(Paises);
                var IdMainProvince = model.Paises.FirstOrDefault().Id;
                var Provincias = America.GetProvinces(Id_Country: IdMainProvince);
                model.Provincias = JsonConvert.DeserializeObject<List<Provinces>>(Provincias);
            }
            return View(model);
        }

        public JsonResult GetProvincesIndex(int Id_Country)
        {
            if (Id_Country != 0)
            {
                var ProvincesJson = America.GetProvinces(Id_Country: Id_Country);
                var Provinces = JsonConvert.DeserializeObject<List<Provinces>>(ProvincesJson);
                if (Provinces.Count > 0)
                {
                    var ModeloList = new System.Web.Mvc.SelectList(Provinces, "Id", "Name");
                    return Json(new { Key = Provinces.FirstOrDefault().Id, Tabla = ModeloList }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json("", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}