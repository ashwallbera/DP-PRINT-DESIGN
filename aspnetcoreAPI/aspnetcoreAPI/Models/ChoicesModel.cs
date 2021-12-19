using System.Runtime.Serialization;

namespace aspnetcoreAPI.Controllers
{

    [DataContract]
    public class ChoicesModel
    {

        [DataMember]
        public string productid { get; set; }

        [DataMember]
        public string categoryid { get; set; }

        [DataMember]
        public string specificationid { get; set; }

        [DataMember]
        public string identification { get; set; }



    }
}
