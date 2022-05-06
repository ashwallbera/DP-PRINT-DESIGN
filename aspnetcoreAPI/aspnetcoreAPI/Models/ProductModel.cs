using System.Runtime.Serialization;

namespace aspnetcoreAPI.Models
{
    [DataContract]
    public class ProductModel
    {

        [DataMember(IsRequired = false)]
        public Guid Id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string imgUri { get; set; } 

        [DataMember]
        public List<CategoryModel> category { get; set; }


        [DataMember]
        public List<SpecificationModel> specification { get; set; }


        [DataMember]
        public bool isDeleted { get; set; }
    }
}
