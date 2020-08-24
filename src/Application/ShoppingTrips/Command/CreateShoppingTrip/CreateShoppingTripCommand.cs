using System;
using Application.Common.Dtos;
using Domain.Entities.ShoppingTripEntity;
using MediatR;

namespace Application.ShoppingTrips.Command.CreateShoppingTrip
{
    public class CreateShoppingTripCommand : IRequest<int>
    {
        public int UserId { get; private set; }
        public int GroupId { get; private set; }
        
        public string Name { get; set; }
        public string Reason { get; set; }
        public DateTime StartTime { get; set; }
        public Transportation Transportation { get; set; }
        public LocationDto Location { get; set; }

        public void Finalize(int userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
    }
}