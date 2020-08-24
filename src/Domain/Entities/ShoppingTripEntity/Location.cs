namespace Domain.Entities.ShoppingTripEntity
{
    public class Location
    {
        // properties
        public string PlaceId { get; set; }
        public string StoreName { get; set; }
        public string FormattedAddress { get; set; }
        public double Rating { get; set; }
        
        // nav properties
        public ShoppingTrip ShoppingTrip { get; set; }
        public int ShoppingTripId { get; set; }
        
    }
}