using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AmericaVirtual_DataModel;
using AmericaVirtual_Web.Areas.Intranet.Controllers;
using AmericaVirtual_Web.Models;
using AmericaVirtualWS;
using Newtonsoft.Json;

namespace AmericaVirtual_Web.Controllers
{
    public class HomeController : Controller
    {
        AmericaVirtualService America = new AmericaVirtualService();
        public ActionResult Index(int Id_Country = 0, int Id_Provinces = 0 )
        {
            BaseModel model = new BaseModel();
            var Paises = America.GetCountries();
            model.Paises = JsonConvert.DeserializeObject<List<Countries>>(Paises);
            var IdMainCountry = model.Paises.FirstOrDefault().Id;
            var Provincias = America.GetProvinces(Id_Country: IdMainCountry);
            model.Provincias = JsonConvert.DeserializeObject<List<Provinces>>(Provincias);
            var IdMainProvince = model.Provincias.FirstOrDefault().Id;
            if (Id_Provinces != 0) IdMainProvince = Id_Provinces;
            var WeatherActual = America.GetWeathers(Id_Province: IdMainProvince);
            var WeatherList = America.GetWeathersWeek(Id_Province: IdMainProvince);
            model.Climas = JsonConvert.DeserializeObject<List<Weather>>(WeatherList);
            model.ClimaPrincipal = JsonConvert.DeserializeObject<List<Weather>>(WeatherActual).Where(x => x.Date == DateTime.Today).FirstOrDefault();
            return View(model);
        }

        public JsonResult GetCountriesIndex()
        {
            var CountriesJson = America.GetCountries();
            var Countries = JsonConvert.DeserializeObject<List<Countries>>(CountriesJson);
            if (Countries.Count > 0)
            {
                var ModeloList = new System.Web.Mvc.SelectList(Countries, "Id", "Name");
                return Json(new { Key = Countries.FirstOrDefault().Id, Tabla = ModeloList }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json("", JsonRequestBehavior.AllowGet);
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
        public JsonResult ChangeWeathersSingleIndex(int Id_Country, int Id_Provincia)
        {
            if (Id_Country != 0 && Id_Provincia != 0)
            {
                var WeathersJsonSingle = America.GetWeathers(Id_Province: Id_Provincia);
                var WeathersPrincipal = JsonConvert.DeserializeObject<List<Weather>>(WeathersJsonSingle).Where(x => x.Date == DateTime.Today).FirstOrDefault();
                var WeathersJson = America.GetWeathersWeek(Id_Province: Id_Provincia);
                var Weathers = JsonConvert.DeserializeObject<List<Weather>>(WeathersJson);
                if (WeathersPrincipal != null)
                {
                    var HtmlPartial = PartialController.RenderPartialViewToString(this, "WeatherPartial", WeathersPrincipal);
                    var HtmlListPartial = PartialController.RenderPartialViewToString(this, "WeatherListPartial", Weathers);
                    return Json(new { Key = true, Weather = HtmlPartial, ListWeather = HtmlListPartial }, JsonRequestBehavior.AllowGet);
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