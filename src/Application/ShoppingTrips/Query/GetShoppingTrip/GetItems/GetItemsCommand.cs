using System.Collections.Generic;
using MediatR;

namespace Application.ShoppingTrips.Query.GetItems
{
    public class GetItemsCommand : IRequest<List<ItemEntryModel>>
    {
        public int UserId { get; }
        public int GroupId { get; }
        public int ShoppingTripId{ get; }

        public GetItemsCommand(int userId, int groupId, int shoppingTripId)
        {
            UserId = userId;
            GroupId = groupId;
            ShoppingTripId = shoppingTripId;
        }
    }
}