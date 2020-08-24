using System;
using MediatR;

namespace Application.Groups.Command.RefreshInviteCode
{
    public class RefreshInviteCodeCommand : IRequest<Guid>
    {
        public int UserId { get; }
        public int GroupId { get; }

        public RefreshInviteCodeCommand(int userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
    }
}