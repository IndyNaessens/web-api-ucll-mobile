using Domain.Entities.MemberEntity;

namespace Domain.Entities.ShoppingTripEntity
{
    public class ShoppingTripItem  : Base
    {
        // properties
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool IsFresh { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        
        // nav properties:
        // shopping trip
        public ShoppingTrip ShoppingTrip { get; set; }
        public int ShoppingTripId { get; set; }
        
        // member
        public Member Member { get; set; }
        public int MemberUserId { get; set; }
        public int MemberGroupId { get; set; }
    }
}