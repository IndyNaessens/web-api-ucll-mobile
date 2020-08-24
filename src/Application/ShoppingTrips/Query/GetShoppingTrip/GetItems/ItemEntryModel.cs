using System;
using Domain.Entities.ShoppingTripEntity;

namespace Application.ShoppingTrips.Query.GetItems
{
    public class ItemEntryModel
    {
        // creator
        public int ItemId { get; }
        public int Amount { get; }    
    
        public string Creator { get;}
        public string Name { get; }
        public Boolean IsFresh { get; }
        public double Price { get; }

        public ItemEntryModel(int itemId, string creator, int amount, string name, Boolean isFresh, double price)
        {
            ItemId = itemId;
            Creator = creator;
            Amount = amount;
            Name = name;
            IsFresh = isFresh;
            Price = price;
        }
    }
}