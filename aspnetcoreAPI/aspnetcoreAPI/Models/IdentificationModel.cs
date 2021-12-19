using System.Runtime.Serialization;

namespace aspnetcoreAPI.Models
{
    [DataContract]
    public class IdentificationModel
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid productid { get; set; }

        [DataMember]
        public Guid specificationid { get; set; }

        [DataMember]
        public string name { get; set; }
    }
}
