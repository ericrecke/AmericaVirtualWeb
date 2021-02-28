using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AmericaVirtual_DataModel
{
    [DataContract]
    public partial class Countries
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime Date_Add { get; set; } = DateTime.Now;

        public virtual ICollection<Provinces> Provinces { get; set; }
        public virtual ICollection<Weather> Weather { get; set; }
        public Countries()
        {
            this.Provinces = new List<Provinces>();
            this.Weather = new List<Weather>();
        }

    }

}
