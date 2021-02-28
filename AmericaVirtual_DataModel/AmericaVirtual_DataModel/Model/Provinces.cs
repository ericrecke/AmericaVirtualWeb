using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AmericaVirtual_DataModel
{
    [DataContract]
    public partial class Provinces
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Id_Country { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime Date_Add { get; set; } = DateTime.Now;
        [DataMember]
        public virtual Countries Countries { get; set; }
        public virtual ICollection<Weather> Weather { get; set; }

        public Provinces()
        {
            this.Weather = new List<Weather>();

        }

    }
}
