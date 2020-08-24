using System.Collections.Generic;
using Domain.Entities.MemberEntity;

namespace Domain.Entities.UserEntity
{
    public class User : Base
    {
        // properties
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; } = Status.Empty;
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        
        // nav properties
        public List<Member> Memberships { get; } = new List<Member>();
    }
}