using AmericaVirtual_DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using AmericaVirtual_DataModel.Manager;
using System.IO;
using System.Web.Mvc;

namespace AmericaVirtual_Web.Models
{
    public class Web_Helper
    {
        public static Users GetUsuario()
        {
            Users usuario = new Users();
            try
            {
                FormsAuthenticationTicket ticket = GetFormsAuthenticationTicket();
                if (ticket != null && !string.IsNullOrEmpty(ticket.UserData))
                {
                    usuario = JsonConvert.DeserializeObject<Users>(ticket.UserData);
                    //Id_Usuario = usuario.Id;
                    //Name = usuario.Name;
                }
            }
            catch (Exception ex) {  }
            return usuario;
        }

        public static FormsAuthenticationTicket GetFormsAuthenticationTicket()
        {
            FormsAuthenticationTicket authTicket = null;
            if (HttpContext.Current.User.Identity.IsAuthenticated)
                authTicket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
            else
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                    authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            if (authTicket != null && !authTicket.Expired && !string.IsNullOrEmpty(authTicket.UserData))
            {
                var user = JsonConvert.DeserializeObject<Users>(authTicket.UserData);
                string rol = user.UserType.ToString();
                string[] rols = { rol};
                HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), rols);
            }
            else
            {
                return null;
            }

            return authTicket;
        }

        public static string SetFormsAuthenticationClientTicket(Users cuser, string[] Roles, bool rememberme, string mail = "", HttpContext context = null)
        {
            var TKcl = cuser;
                HttpContext.Current.Session["User-Name"] = TKcl.Name;
                HttpContext.Current.Session["User-Mail"] = TKcl.Email;

            var usuario = new Users()
            {
                Id = TKcl.Id,
                Name = TKcl.Name == string.Empty ? TKcl.Email : TKcl.Name,
                Email = mail,
                Date_Add = TKcl.Date_Add,
                UserType = TKcl.UserType,
            };
            string Userdata = SetAuthenticationTicket((EnumTypeUser)TKcl.UserType, usuario, rememberme, context);

            return Userdata;

        }

        private static string SetAuthenticationTicket(EnumTypeUser TipoUsuario, Users usuario, bool rememberme, HttpContext context = null)
        {
            FormsAuthentication.SetAuthCookie(usuario.Name, true);
            string UserData = JsonConvert.SerializeObject(usuario);
            var authTicket = new FormsAuthenticationTicket(1, usuario.Name, DateTime.Now, DateTime.Now.AddMinutes(30), rememberme, UserData);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            if (context == null) context = HttpContext.Current;
            context.Response.Cookies.Add(authCookie);
            string rol = usuario.UserType.ToString();
            string[] rols = { rol };
            context.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), rols);
            HttpContext.Current = context;
            return UserData;
        }

        public static string GetImage(EnumTypeWeather TypeWeather)
        {
            var Strreturn = "";
            switch (TypeWeather)
            {
                case EnumTypeWeather.Soleado:
                    Strreturn = "/Content/Images/Weather-Icons/Sun.png";
                    break;
                case EnumTypeWeather.Nublado:
                    Strreturn = "/Content/Images/Weather-Icons/Cloudy.png";
                    break;
                case EnumTypeWeather.Parcialmente_Nublado:
                    Strreturn = "/Content/Images/Weather-Icons/Partly_Cloudy.png";
                    break;
                case EnumTypeWeather.Lluvia:
                    Strreturn = "/Content/Images/Weather-Icons/Rain.png";
                    break;
                case EnumTypeWeather.Lluvia_Electrica:
                    Strreturn = "/Content/Images/Weather-Icons/ElectrinRain.png";
                    break;
                case EnumTypeWeather.Nieve:
                    Strreturn = "/Content/Images/Weather-Icons/Snow.png";
                    break;
            }
            return Strreturn;
        }
    }
}