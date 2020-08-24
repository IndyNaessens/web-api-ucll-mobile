using System.Collections.Generic;
using MediatR;

namespace Application.Groups.Query.GetShoppingTrips
{
    public class GetShoppingTripsCommand : IRequest<List<ShoppingTripEntryModel>>
    {
        public int UserId { get; }
        public int GroupId { get; }

        public GetShoppingTripsCommand(int userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
    }
}