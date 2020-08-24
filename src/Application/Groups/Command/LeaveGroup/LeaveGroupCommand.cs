using MediatR;

namespace Application.Groups.Command.LeaveGroup
{
    public class LeaveGroupCommand : IRequest
    {
        public int UserId { get; }
        public int GroupId { get; }

        public LeaveGroupCommand(int userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
        
    }
}