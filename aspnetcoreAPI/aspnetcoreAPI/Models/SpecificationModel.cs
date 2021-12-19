using System.Runtime.Serialization;

namespace aspnetcoreAPI.Models
{
    [DataContract]
    public class SpecificationModel
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid productid { get; set; }

        [DataMember]
        public Guid categoryid { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public List<IdentificationModel> identification { get; set; }
    }
}
