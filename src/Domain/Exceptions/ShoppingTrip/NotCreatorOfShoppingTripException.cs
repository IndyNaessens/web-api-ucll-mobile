using System;

namespace Domain.Exceptions.ShoppingTrip
{
    public class NotCreatorOfShoppingTripException : Exception
    {
        public NotCreatorOfShoppingTripException() : base("You are not the creator of the shopping trip")
        {
        }
    }
}