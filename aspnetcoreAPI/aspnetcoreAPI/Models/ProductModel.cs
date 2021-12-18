using System.Runtime.Serialization;

namespace aspnetcoreAPI.Models
{
    [DataContract]
    public class ProductModel
    {

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string imgUri { get; set; } 

        [DataMember]
        public string categoryid { get; set; }

        [DataMember]
        public bool isDeleted { get; set; }
    }
}
