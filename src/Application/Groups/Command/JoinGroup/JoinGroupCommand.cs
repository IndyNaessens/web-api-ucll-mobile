using System;
using MediatR;

namespace Application.Groups.Command.JoinGroup
{
    public class JoinGroupCommand : IRequest<int>
    {
        public int UserId { get; private set; }
        public Guid InviteCode { get; set; }

        public void Finalize(int userId) => UserId = userId;
    }
}