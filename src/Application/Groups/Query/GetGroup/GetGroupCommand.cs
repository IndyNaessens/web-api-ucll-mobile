using MediatR;

namespace Application.Groups.Query.GetGroup
{
    public class GetGroupCommand : IRequest<GroupModel>
    {
        public int UserId { get; }
        public int GroupId { get; }

        public GetGroupCommand(int userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
    }
}