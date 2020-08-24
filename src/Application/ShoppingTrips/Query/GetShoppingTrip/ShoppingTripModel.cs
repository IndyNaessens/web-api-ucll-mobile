using System;
using System.Collections.Generic;
using Application.Common.Dtos;
using Domain.Entities.ShoppingTripEntity;

namespace Application.ShoppingTrips.Query.GetShoppingTrip
{
    public class ShoppingTripModel
    {
        public string Creator { get; }
        public string Name { get; }
        public string Reason { get; }
        public DateTime StartTime { get; }
        public Transportation Transportation { get; }
        public LocationDto Location { get; }
        public List<ShoppingTripItemModel> ShoppingTripItems { get; }

        public ShoppingTripModel(string creator, string name, string reason, DateTime startTime, Transportation transportation, LocationDto location, List<ShoppingTripItemModel> shoppingTripItems)
        {
            Creator = creator;
            Name = name;
            Reason = reason;
            StartTime = startTime;
            Transportation = transportation;
            Location = location;
            ShoppingTripItems = shoppingTripItems;
        }
    }
}