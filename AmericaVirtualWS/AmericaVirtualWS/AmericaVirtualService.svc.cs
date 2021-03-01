using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AmericaVirtual_DataModel;
using Newtonsoft.Json;
namespace AmericaVirtualWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AmericaVirtualService : IAmericaVirtualService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string ValidateLogin(string user, string pass)
        {
            try
            {
                var db = new AmericaVirtualContext();
                var UserExist = db.Users.Where(x => x.Email == user && x.Password == pass).FirstOrDefault();
                AddLog("Login Usuario " + UserExist.Name);
                if (UserExist != null) return JsonConvert.SerializeObject(UserExist);
                else return "";
            }

            catch (Exception ex)
            {
                return "";
            }
        }

        public string GetCountries(int Id_Country = 0)
        {
            try
            {
                var db = new AmericaVirtualContext();
                var Countries = db.Countries.Where(x => (Id_Country == 0 || x.Id == Id_Country)).ToList();
                AddLog("Obtener Países");
                return JsonConvert.SerializeObject(Countries);
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        public string GetProvinces(int Id_Province = 0, int Id_Country = 0)
        {
            try
            {
                var db = new AmericaVirtualContext();
                var Provinces = db.Provinces.Include("Countries").Where(x => (Id_Country == 0 || x.Id_Country == Id_Country) && (Id_Province == 0 || x.Id == Id_Province)).ToList();
                AddLog("Obtener Provincias");
                return JsonConvert.SerializeObject(Provinces);
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }
        public string GetUsers(int Id_User = 0)
        {
            try
            {
                var db = new AmericaVirtualContext();
                var Users = db.Users.Where(x => (Id_User == 0 || x.Id == Id_User)).ToList();
                AddLog("Obtener Usuario");
                return JsonConvert.SerializeObject(Users);
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }
        public string GetWeathers(int Id_Weather = 0, int Id_Province = 0)
        {
            try
            {
                var db = new AmericaVirtualContext();
                var Weathers = db.Weather.Include("Countries").Include("Provinces").Where(x => (Id_Weather == 0 || x.Id == Id_Weather) && (Id_Province == 0 || x.Id_Province == Id_Province)).OrderBy(x => x.Date).ToList();
                AddLog("Obtener Climas");
                return JsonConvert.SerializeObject(Weathers);
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        public string GetWeathersWeek(int Id_Weather = 0, int Id_Province = 0)
        {
            try
            {
                var db = new AmericaVirtualContext();
                var Weathers = db.Weather.Include("Countries").Include("Provinces").Where(x => (Id_Weather == 0 || x.Id == Id_Weather) && (Id_Province == 0 || x.Id_Province == Id_Province) && (x.Date >= DateTime.Today)).OrderByDescending(x => x.Id).OrderBy(x => x.Date).Take(5).ToList();
                AddLog("Obtener Los ultimos 5 Dias del Clima");
                return JsonConvert.SerializeObject(Weathers);
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        public void AddLog(string Services)
        {
            var db = new AmericaVirtualContext();
            var Log = new Services_Log() { Service = Services, Date_Add = DateTime.Today };
            db.Services_Log.Add(Log);
            db.SaveChanges();
        }

        public string AddModCountry(Countries model, string delete = "0")
        {
            try
            {
                var db = new AmericaVirtualContext();
                if (delete != "0")
                {
                    var modDel = db.Countries.Where(x => x.Id == model.Id).FirstOrDefault();
                    db.Countries.Remove(modDel);
                    AddLog("Eliminar País " + modDel.Name);
                }
                else
                {
                    if (model.Id == 0)
                    {
                        db.Countries.Add(model);
                        AddLog("Agregar País " + model.Name);
                    }
                    else
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        AddLog("Modificar País " + model.Name);
                    }
                }
                db.SaveChanges();

                return model.Id.ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        public string AddModProvince(Provinces model, string delete = "0")
        {
            try
            {
                var db = new AmericaVirtualContext();
                if (delete != "0")
                {
                    var modDel = db.Provinces.Where(x => x.Id == model.Id).FirstOrDefault();
                    db.Provinces.Remove(modDel);
                    AddLog("Agregar Provincia " + model.Name);
                }
                else
                {
                    if (model.Id == 0)
                    {
                        db.Provinces.Add(model);
                        AddLog("Modificar Provincia " + model.Name);
                    }
                    else
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        AddLog("Eliminar Provincia " + model.Name);
                    }
                }
                db.SaveChanges();

                return model.Id.ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        public string AddModUser(Users model, string delete = "0")
        {
            try
            {
                var db = new AmericaVirtualContext();
                if (delete != "0")
                {
                    var modDel = db.Users.Where(x => x.Id == model.Id).FirstOrDefault();
                    db.Users.Remove(modDel);
                    AddLog("Eliminar Usuario " + model.Name);
                }
                else
                {
                    if (model.Id == 0)
                    {
                        db.Users.Add(model);
                        AddLog("Agregar Usuario " + model.Name);
                    }
                    else
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        AddLog("Modificar Usuario " + model.Name);
                    }
                }
                db.SaveChanges();

                return model.Id.ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        public string AddModWeather(Weather model, string delete = "0")
        {
            try
            {
                var db = new AmericaVirtualContext();
                if (delete != "0")
                {
                    var modDel = db.Weather.Where(x => x.Id == model.Id).FirstOrDefault();
                    db.Weather.Remove(modDel);
                    AddLog("Eliminar Clima Fecha " + modDel.Date);
                }
                else
                {
                    if (model.Id == 0)
                    {
                        db.Weather.Add(model);
                        AddLog("Agregar Clima Fecha " + model.Date);
                    }
                    else
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        AddLog("Modificar Clima Fecha " + model.Date);
                    }
                }
                db.SaveChanges();

                return model.Id.ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
    }
}
