using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AmericaVirtual_DataModel
{
    [DataContract]
    public partial class Weather
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Id_Country { get; set; }
        [DataMember]
        public int Id_Province { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public decimal Sensation_C { get; set; }
        [DataMember]
        public decimal Sensation_F { get; set; }
        [DataMember]
        public int Rainfall { get; set; }
        [DataMember]
        public int Humidity { get; set; }
        [DataMember]
        public int Wind { get; set; }
        public DateTime Date_Add { get; set; } = DateTime.Now;
        public virtual Countries Countries { get; set; }
        public virtual Provinces Provinces { get; set; }
    }
}

