using MediatR;

namespace Application.Groups.Command.ChangeGroupName
{
    public class ChangeGroupNameCommand : IRequest
    {
        public int UserId { get; private set; }
        public int GroupId { get; private set; }
        public string Name { get; set; }

        public void Finalize(int userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
        
    }
}