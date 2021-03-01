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

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        [WebInvoke(Method = "GET")]
        string ValidateLogin(string user = "", string pass = "");

        [OperationContract]
        [WebInvoke(Method = "GET")]
        string GetCountries(int Id_Country);
        [OperationContract]
        [WebInvoke(Method = "GET")]
        string GetProvinces(int Id_Province, int Id_Country = 0);
        [OperationContract]
        [WebInvoke(Method = "GET")]
        string GetUsers(int Id_User);
        [OperationContract]
        [WebInvoke(Method = "GET")]
        string GetWeathers(int Id_Weather, int Id_Province);
        [OperationContract]
        [WebInvoke(Method = "GET")]
        string GetWeathersWeek(int Id_Weather, int Id_Province);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddModCountry/{delete=0}")]
        string AddModCountry(Countries model, string delete = "0");
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddModProvince/{delete=0}")]
        string AddModProvince(Provinces model, string delete = "0");
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddModUser/{delete=0}")]
        string AddModUser(Users model, string delete = "0");
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddModWeather/{delete=0}")]
        string AddModWeather(Weather model, string delete = "0");
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
