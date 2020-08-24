using System;

namespace Domain.Exceptions.User
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() : base("The user already exists")
        {
            
        }
    }
}