using System;
using System.Collections.Generic;
using Domain.Entities.MemberEntity;

namespace Domain.Entities.ShoppingTripEntity
{
    public class ShoppingTrip : Base
    {
        // properties
        
        // name of your shop trip
        public string Name { get; set; }
        
        // some information about your shop trip
        public string Reason { get; set; }
        
        public DateTime StartTime { get; set; }
        public Transportation Transportation { get; set; }
        
        // nav properties:
        // items
        public List<ShoppingTripItem> Items { get; } = new List<ShoppingTripItem>();
        
        // location
        public Location Location { get; set; }
        
        // member 
        public Member Member { get; set; }
        public int MemberUserId { get; set; }
        public int MemberGroupId { get; set; }
    }
}