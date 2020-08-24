using Domain.Entities.UserEntity;

namespace Application.Common.Dtos
{
    public class UserDto
    {
        // properties
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Status Status { get; set; } 
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
    }
}