using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericaVirtual_DataModel
{
    public partial class Provinces
    {
        public int Id { get; set; }
        public int Id_Country { get; set; }
        public string Name { get; set; }

        public virtual Countries Countries { get; set; }
        public virtual ICollection<Weather> Weather { get; set; }

        public Provinces()
        {
            this.Weather = new List<Weather>();

        }

    }
}
