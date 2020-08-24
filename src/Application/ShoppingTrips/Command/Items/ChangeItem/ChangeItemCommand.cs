using Application.Common.Dtos;
using MediatR;

namespace Application.ShoppingTrips.Command.Items.ChangeItem
{
    public class ChangeItemCommand : IRequest
    {
        public int UserId { get; private set; }
        public int GroupId { get; private set; }
        public int ShoppingTripId { get; private set; }
        public int ShoppingTripItemId { get; private set; }

        public ShoppingTripItemDto UpdatedShoppingTripItem { get; set; }
        
        public void Finalize(int userId, int groupId, int shoppingTripId, int shoppingTripItemId)
        {
            UserId = userId;
            GroupId = groupId;
            ShoppingTripId = shoppingTripId;
            ShoppingTripItemId = shoppingTripItemId;
        }
    }
}