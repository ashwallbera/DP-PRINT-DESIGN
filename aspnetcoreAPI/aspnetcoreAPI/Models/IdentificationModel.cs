using System.Runtime.Serialization;

namespace aspnetcoreAPI.Models
{
    [DataContract]
    public class IdentificationModel
    {
        [DataMember(IsRequired = false)]
        public Guid Id { get; set; }

        [DataMember(IsRequired = false)]
        public Guid productid { get; set; }

        [DataMember]
        public Guid specificationid { get; set; }

        [DataMember]
        public string name { get; set; }
    }
}
