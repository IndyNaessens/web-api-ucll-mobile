using System;

namespace Domain.Exceptions.Group
{
    public class UserNotMemberOfGroupException : Exception
    {
        public UserNotMemberOfGroupException() : base("You are not a member of the grouo")
        {
            
        }
    }
}