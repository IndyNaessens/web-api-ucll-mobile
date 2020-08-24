using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions.ShoppingTrip
{
    public class NoAccessToShoppingTripException : Exception
    {
        public NoAccessToShoppingTripException() : base("You have no access to the shopping trip")
        {

        }
    }
}
