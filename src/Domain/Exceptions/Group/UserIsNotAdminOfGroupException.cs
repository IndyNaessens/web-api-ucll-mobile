using System;

namespace Domain.Exceptions.Group
{
    public class UserIsNotAdminOfGroupException : Exception
    {
        public UserIsNotAdminOfGroupException() : base("You are not admin of this group")
        {
            
        }
    }
}