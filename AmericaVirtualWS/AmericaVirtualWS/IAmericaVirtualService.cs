using AmericaVirtual_DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AmericaVirtualWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAmericaVirtualService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        string ValidateLogin(string user, string pass);

        [OperationContract]
        string GetCountries(int Id_Country);
        [OperationContract]
        string GetProvinces(int Id_Province, int Id_Country = 0);
        [OperationContract]
        string GetUsers(int Id_User);
        [OperationContract]
        string GetWeathers(int Id_Weather, int Id_Province);
        [OperationContract]
        string GetWeathersWeek(int Id_Weather, int Id_Province);
        [OperationContract]
        string AddModCountry(Countries model, bool delete = false);
        [OperationContract]
        string AddModProvince(Provinces model, bool delete = false);
        [OperationContract]
        string AddModUser(Users model, bool delete = false);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
