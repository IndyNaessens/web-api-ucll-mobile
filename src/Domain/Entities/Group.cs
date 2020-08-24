using System;
using System.Collections.Generic;
using Domain.Entities.MemberEntity;

namespace Domain.Entities
{
    public class Group : Base
    {
        // properties
        public string Name { get; set; }
        public DateTime CreationDate { get; } = DateTime.Now;
        public Guid InviteCode { get; set; } = Guid.NewGuid();
        
        // nav properties
        public List<Member> Memberships { get; } = new List<Member>();
    }
}