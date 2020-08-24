using System;

namespace Domain.Exceptions.Group
{
    public class InvalidInviteCodeException : Exception
    {
        public InvalidInviteCodeException() : base("The invite code is not valid")
        {
            
        }
    }
}