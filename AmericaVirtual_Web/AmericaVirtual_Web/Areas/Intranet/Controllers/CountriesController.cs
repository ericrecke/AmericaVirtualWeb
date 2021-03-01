using AmericaVirtual_DataModel;
using AmericaVirtualWS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmericaVirtual_Web.Areas.Intranet.Controllers
{    
    public class CountriesController : Controller
    {
        // GET: Intranet/Countries
        AmericaVirtualService America = new AmericaVirtualService();
        [Authorize(Roles = "2")]
        public ActionResult Index()
        {
            var CountriesJson = America.GetCountries();
            var ListCountries = JsonConvert.DeserializeObject<List<Countries>>(CountriesJson);
            return View(ListCountries);
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public ActionResult AddMod(int id = 0)
        {
            var model = new Countries();
            if (id != 0)
            {
                var CountriesJson = America.GetCountries(id);
                var ListCountries = JsonConvert.DeserializeObject<List<Countries>>(CountriesJson);
                model = ListCountries.FirstOrDefault();
            }
            return PartialView("~/Areas/Intranet/Views/Countries/Partial/CountryAddModPartial.cshtml", model);
        }

        [Authorize(Roles = "2")]
        public ActionResult UpdateCountry(Countries model, bool delete = false)
        {
            var borrar = "0";
            if (delete) borrar = "1";
            var checkSend = America.AddModCountry(model, borrar);
            return RedirectToAction("Index", "Countries", new { Area = "Intranet" });
        }
    }
}