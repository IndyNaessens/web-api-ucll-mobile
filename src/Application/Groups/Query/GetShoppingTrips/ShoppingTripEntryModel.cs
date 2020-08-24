using System;
using Domain.Entities.ShoppingTripEntity;

namespace Application.Groups.Query.GetShoppingTrips
{
    public class ShoppingTripEntryModel
    {
        // creator
        public int ShoppingTripId { get; }
        public string Creator { get; }    
        
        public string Name { get; }
        public DateTime StartTime { get; }
        public Transportation Transportation { get; }

        public ShoppingTripEntryModel(int shoppingTripId, string creator, string name, DateTime startTime, Transportation transportation)
        {
            ShoppingTripId = shoppingTripId;
            Creator = creator;
            Name = name;
            StartTime = startTime;
            Transportation = transportation;
        }
    }
}