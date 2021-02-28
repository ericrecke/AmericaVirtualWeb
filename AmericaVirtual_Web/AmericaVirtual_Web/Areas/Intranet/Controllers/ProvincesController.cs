using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmericaVirtual_DataModel;
using AmericaVirtualWS;
using Newtonsoft.Json;
namespace AmericaVirtual_Web.Areas.Intranet.Controllers
{
    public class ProvincesController : Controller
    {
        // GET: Intranet/Provinces
        AmericaVirtualService America = new AmericaVirtualService();
        [Authorize(Roles = "2")]
        public ActionResult Index()
        {
            var ProvincesJson = America.GetProvinces();
            var ListProvinces = JsonConvert.DeserializeObject<List<Provinces>>(ProvincesJson);
            return View(ListProvinces);
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public ActionResult AddMod(int id = 0)
        {
            var model = new Provinces();
            if (id != 0)
            {
                var CountriesJson = America.GetProvinces(id);
                var ListProvinces = JsonConvert.DeserializeObject<List<Provinces>>(CountriesJson);
                model = ListProvinces.FirstOrDefault();
            }
            return PartialView("~/Areas/Intranet/Views/Provinces/Partial/ProvinceAddModPartial.cshtml", model);
        }

        [Authorize(Roles = "2")]
        public ActionResult UpdateProvince(Provinces model, bool delete = false)
        {
            var checkSend = America.AddModProvince(model, delete);
            return RedirectToAction("Index", "Provinces", new { Area = "Intranet" });
        }

    }
}