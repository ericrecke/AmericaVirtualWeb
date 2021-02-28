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
                var Weathers = db.Weather.Where(x => (Id_Weather == 0 || x.Id == Id_Weather) && (Id_Province == 0 || x.Id_Province == Id_Province)).ToList();
                return JsonConvert.SerializeObject(Weathers);
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }
        public string AddModCountry(Countries model, bool delete = false)
        {
            try
            {
                var db = new AmericaVirtualContext();
                if (delete)
                {
                    var modDel = db.Countries.Where(x => x.Id == model.Id).FirstOrDefault();
                    db.Countries.Remove(modDel);
                }
                else
                {
                    if (model.Id == 0)
                    {
                        db.Countries.Add(model);
                    }
                    else
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
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
        public string AddModProvince(Provinces model, bool delete = false)
        {
            try
            {
                var db = new AmericaVirtualContext();
                if (delete)
                {
                    var modDel = db.Provinces.Where(x => x.Id == model.Id).FirstOrDefault();
                    db.Provinces.Remove(modDel);
                }
                else
                {
                    if (model.Id == 0)
                    {
                        db.Provinces.Add(model);
                    }
                    else
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
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

        public string AddModUser(Users model, bool delete = false)
        {
            try
            {
                var db = new AmericaVirtualContext();
                if (delete)
                {
                    var modDel = db.Users.Where(x => x.Id == model.Id).FirstOrDefault();
                    db.Users.Remove(modDel);
                }
                else
                {
                    if (model.Id == 0)
                    {
                        db.Users.Add(model);
                    }
                    else
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
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
        public string AddModWeather(Weather model, bool delete = false)
        {
            try
            {
                var db = new AmericaVirtualContext();
                if (delete)
                {
                    var modDel = db.Weather.Where(x => x.Id == model.Id).FirstOrDefault();
                    db.Weather.Remove(modDel);
                }
                else
                {
                    if (model.Id == 0)
                    {
                        db.Weather.Add(model);
                    }
                    else
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
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
