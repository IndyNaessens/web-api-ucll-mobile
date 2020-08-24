using Domain.Entities.UserEntity;
using MediatR;

namespace Application.Users.Command.ChangeUserStatus
{
    public class ChangeUserStatusCommand : IRequest
    {
        public int UserId { get; private set; }
        public Status Status { get; set; }

        public void Finalize(int userId) => UserId = userId;
    }
}