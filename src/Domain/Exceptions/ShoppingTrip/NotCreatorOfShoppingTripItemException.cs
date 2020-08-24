using System;

namespace Domain.Exceptions.ShoppingTrip
{
    public class NotCreatorOfShoppingTripItemException : Exception
    {
        public NotCreatorOfShoppingTripItemException() : base("You are not the creator of the shopping trip item"){}
    }
}