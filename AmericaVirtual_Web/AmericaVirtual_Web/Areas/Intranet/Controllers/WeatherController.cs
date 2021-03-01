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
    public class WeatherController : Controller
    {
        // GET: Intranet/Provinces
        AmericaVirtualService America = new AmericaVirtualService();
        [Authorize(Roles = "2")]
        public ActionResult Index()
        {
            var WeatherJson = America.GetWeathers();
            var ListWeather = JsonConvert.DeserializeObject<List<Weather>>(WeatherJson);
            return View(ListWeather);
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public ActionResult AddMod(int id = 0)
        {
            var model = new Weather();
            if (id != 0)
            {
                var WeatherJson = America.GetWeathers(id);
                var ListWeather = JsonConvert.DeserializeObject<List<Weather>>(WeatherJson);
                model = ListWeather.FirstOrDefault();
            }
            return PartialView("~/Areas/Intranet/Views/Weather/Partial/WeatherAddModPartial.cshtml", model);
        }

        [Authorize(Roles = "2")]
        public ActionResult UpdateWeather(Weather model, bool delete = false)
        {
            var borrar = "0";
            if (delete) borrar = "1";
            var checkSend = America.AddModWeather(model, borrar);
            return RedirectToAction("Index", "Weather", new { Area = "Intranet" });
        }
    }
}