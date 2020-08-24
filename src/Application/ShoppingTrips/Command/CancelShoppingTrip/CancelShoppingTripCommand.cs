using MediatR;

namespace Application.ShoppingTrips.Command.CancelShoppingTrip
{
    public class CancelShoppingTripCommand : IRequest
    {
        public int UserId { get; }
        public int GroupId { get; }
        public int ShoppingTripId { get; }

        public CancelShoppingTripCommand(int userId, int groupId, int shoppingTripId)
        {
            UserId = userId;
            GroupId = groupId;
            ShoppingTripId = shoppingTripId;
        }
    }
}