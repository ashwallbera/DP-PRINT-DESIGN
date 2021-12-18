using Microsoft.AspNetCore.Identity;
using System.Runtime.Serialization;

namespace aspnetcoreAPI.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string email{ get; set; }
        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string firstname { get; set; }

        [DataMember]
        public string lastname { get; set; }

        [DataMember]
        public string role { get; set; }
    }
}
