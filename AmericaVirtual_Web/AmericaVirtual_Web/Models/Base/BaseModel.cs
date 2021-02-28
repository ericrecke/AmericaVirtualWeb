using AmericaVirtual_DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericaVirtual_Web.Models
{
    public class BaseModel
    {
        public List<Countries> Paises { get; set; }
        public List<Provinces> Provincias { get; set; }
        public int Id_Pais { get; set; }
        public int Id_Provincia { get; set; }

        public Weather ClimaPrincipal { get; set; }
        public List<Weather> Climas { get; set; }

    }
}