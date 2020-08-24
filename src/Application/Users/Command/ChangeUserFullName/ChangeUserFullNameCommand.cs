using MediatR;

namespace Application.Users.Command.ChangeUserFullName
{
    public class ChangeUserFullNameCommand : IRequest
    {
        public int UserId { get; private set; }
        public string FistName { get; set; }
        public string LastName { get; set; }

        public void Finalize(int userId) => UserId = userId;
    }
}