using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using AmericaVirtual_DataModel.Manager;

namespace AmericaVirtual_DataModel
{
    [DataContract]
    public partial class Users
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public EnumTypeUser UserType { get; set; } = EnumTypeUser.Usuario;
        [DataMember]
        public DateTime Date_Add { get; set; } = DateTime.Now;

    }

}
