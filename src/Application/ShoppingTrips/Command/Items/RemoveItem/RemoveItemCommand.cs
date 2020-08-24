using MediatR;

namespace Application.ShoppingTrips.Command.Items.RemoveItem
{
    public class RemoveItemCommand : IRequest
    {
        public int ItemId { get; }
        public int UserId { get; }
        public int GroupId { get; }
        public int ShoppingTripId { get; }

        public RemoveItemCommand(int itemId, int userId, int groupId, int shoppingTripId)
        {
            ItemId = itemId;
            UserId = userId;
            GroupId = groupId;
            ShoppingTripId = shoppingTripId;
        }
    }
}