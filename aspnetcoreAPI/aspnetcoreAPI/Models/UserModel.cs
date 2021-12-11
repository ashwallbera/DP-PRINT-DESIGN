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
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }
    }
}
