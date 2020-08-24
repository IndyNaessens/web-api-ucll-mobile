using Application.Common.Dtos;
using MediatR;

namespace Application.ShoppingTrips.Command.Items.AddItem
{
    public class AddItemCommand : IRequest<int>
    {
        public int UserId { get; private set; }
        public int GroupId { get; private set; }
        public int ShoppingTripId { get; private set; }

        public ShoppingTripItemDto ShoppingTripItem { get; set; }

        public void Finalize(int userId, int groupId, int shoppingTripId)
        {
            UserId = userId;
            GroupId = groupId;
            ShoppingTripId = shoppingTripId;
        }
    }
}
