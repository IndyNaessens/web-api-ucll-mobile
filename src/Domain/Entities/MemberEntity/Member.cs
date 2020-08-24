using System.Collections.Generic;
using Domain.Entities.ShoppingTripEntity;
using Domain.Entities.UserEntity;

namespace Domain.Entities.MemberEntity
{
    /// <summary>
    /// A user that is part/member of a specific group
    /// </summary>
    public class Member 
    {
        // properties
        public bool IsAdmin { get; set; }
        
        // nav properties:
        // user
        public User User { get; set; }
        public int UserId { get; set; }
        
        // group
        public Group Group { get; set; }
        public int GroupId { get; set; }
        
        // collections
        public List<Message> Messages { get; } = new List<Message>();
        public List<ShoppingTrip> ShoppingTrips { get; } = new List<ShoppingTrip>();
        public List<ShoppingTripItem> ShoppingTripItems { get; } = new List<ShoppingTripItem>();
    }
}