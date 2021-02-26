using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericaVirtual_DataModel
{
    public partial class Weather
    {
        public int Id { get; set; }
        public int Id_Country { get; set; }
        public int Id_Province { get; set; }
        public DateTime Date { get; set; }
        public decimal Sensation_C { get; set; }
        public decimal Sensation_F { get; set; }
        public int Rainfall { get; set; }
        public int Humidity { get; set; }
        public int Wind { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual Provinces Provinces { get; set; }
    }
}

