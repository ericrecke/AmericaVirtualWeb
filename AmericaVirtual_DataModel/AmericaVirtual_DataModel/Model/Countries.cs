using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericaVirtual_DataModel
{
    public partial class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date_Add { get; set; }

        public virtual ICollection<Provinces> Provinces { get; set; }
        public virtual ICollection<Weather> Weather { get; set; }
        public Countries()
        {
            this.Provinces = new List<Provinces>();
            this.Weather = new List<Weather>();
        }

    }

}
