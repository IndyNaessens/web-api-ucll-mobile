using System;

namespace Domain.Entities.MemberEntity
{
    public class Message  : Base
    {
        // properties
        public string Content { get; set; }
        public DateTime SendAt { get; set; } = DateTime.Now;
        
        // nav properties
        public Member Member { get; set; }
        public int MemberUserId { get; set; }
        public int MemberGroupId { get; set; }
    }
}