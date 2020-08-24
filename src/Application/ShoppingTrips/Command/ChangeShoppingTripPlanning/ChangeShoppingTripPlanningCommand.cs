using System;
using Application.Common.Dtos;
using Domain.Entities.ShoppingTripEntity;
using MediatR;

namespace Application.ShoppingTrips.Command.ChangeShoppingTripPlanning
{
    public class ChangeShoppingTripPlanningCommand : IRequest
    {
        public int UserId { get; private set; }
        public int GroupId { get; private set; }
        public int ShoppingTripId { get; private set; }
        
        public DateTime StartTime { get; set; }
        public Transportation Transportation { get; set; }
        public LocationDto Location { get; set; }
        
        public void Finalize(int userId, int groupId, int shoppingTripId)
        {
            UserId = userId;
            GroupId = groupId;
            ShoppingTripId = shoppingTripId;
        }
    }
}