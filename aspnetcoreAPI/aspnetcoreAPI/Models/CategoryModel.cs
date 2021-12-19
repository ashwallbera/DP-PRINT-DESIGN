using System.Runtime.Serialization;

namespace aspnetcoreAPI.Models
{
    [DataContract]
    public class CategoryModel
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid productid { get; set; }

        [DataMember]
        public string name { get; set; }
    }
}
