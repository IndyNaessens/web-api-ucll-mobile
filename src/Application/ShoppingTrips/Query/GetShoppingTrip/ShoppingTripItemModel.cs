namespace Application.ShoppingTrips.Query.GetShoppingTrip
{
    public class ShoppingTripItemModel
    {
        public string CreatedBy { get; }
        public string Name { get; }
        public int Amount { get; }
        public bool IsFresh { get; }
        public double Price { get; }
        public string ImageUrl { get; }

        public ShoppingTripItemModel(string createdBy, string name, int amount, bool isFresh, double price, string imageUrl)
        {
            CreatedBy = createdBy;
            Name = name;
            Amount = amount;
            IsFresh = isFresh;
            Price = price;
            ImageUrl = imageUrl;
        }
    }
}