namespace Application.Common.Dtos
{
    public class ShoppingTripItemDto
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool IsFresh { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}