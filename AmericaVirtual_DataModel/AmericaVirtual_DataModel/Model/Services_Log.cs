using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmericaVirtual_DataModel
{
    public partial class Services_Log
    {
        public int Id { get; set; }
        public string Service { get; set; }
        public int Id_User_Add { get; set; }
        public DateTime Date_Add { get; set; }
    }
}