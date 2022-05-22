using System.Runtime.Serialization;

namespace aspnetcoreAPI.Models
{
    [DataContract]
    public class ShippingModel
    {
        [DataMember]
        public Guid id { get; set; }
        [DataMember]
        public Guid customerid { get; set; }

        [DataMember]
        public Guid orderno { get; set; }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string address   { get; set; }

        [DataMember]
        public string fullname { get; set; }

        [DataMember]
        public string paymentMethod { get; set; }

        [DataMember]
        public bool isDeleted { get; set; }

        [DataMember(IsRequired =false)]
        public List<CartModel> cart { get; set; }

    }
}
