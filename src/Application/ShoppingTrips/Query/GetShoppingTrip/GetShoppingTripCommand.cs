using MediatR;

namespace Application.ShoppingTrips.Query.GetShoppingTrip
{
    public class GetShoppingTripCommand : IRequest<ShoppingTripModel>
    {
        public int UserId { get; }
        public int GroupId { get; }
        public int ShoppingTripId { get; }

        public GetShoppingTripCommand(int userId, int groupId, int shoppingTripId)
        {
            UserId = userId;
            GroupId = groupId;
            ShoppingTripId = shoppingTripId;
        }
    }
}