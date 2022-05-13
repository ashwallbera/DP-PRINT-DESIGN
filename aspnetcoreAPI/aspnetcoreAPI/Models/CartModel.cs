using System.Runtime.Serialization;

namespace aspnetcoreAPI.Models
{
    [DataContract]
    public class CartModel
    {
        [DataMember(IsRequired =false)]
        public Guid Id { get; set; }

        [DataMember]
        public Guid customerid { get; set; }

        [DataMember]
        public Guid productId { get; set; }

        [DataMember]
        public string specification { get; set; }

        [DataMember(IsRequired = false)]
        public string price { get; set; }

        [DataMember(IsRequired =false)]
        public string created { get; set; }

        [DataMember(IsRequired = false)]
        public List<ProductModel> product { get; set; }

        [DataMember(IsRequired =false)]
        public bool isDeleted { get; set; }
    }
}
