using MediatR;

namespace Application.ShoppingTrips.Command.ChangeShoppingTripInfo
{
    public class ChangeShoppingTripInfoCommand : IRequest
    {
        public int UserId { get; private set; }
        public int GroupId { get; private set; }
        public int ShoppingTripId { get; private set; }
        
        public string Name { get; set; }
        public string Reason { get; set; }
        
        public void Finalize(int userId, int groupId, int shoppingTripId)
        {
            UserId = userId;
            GroupId = groupId;
            ShoppingTripId = shoppingTripId;
        }
    }
}