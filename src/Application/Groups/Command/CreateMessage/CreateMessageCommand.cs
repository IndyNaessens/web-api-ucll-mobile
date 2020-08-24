using MediatR;

namespace Application.Groups.Command.CreateMessage
{
    public class CreateMessageCommand : IRequest<int>
    {
        public int UserId { get; private set; }
        public int GroupId { get; private set; }
        public string Content { get; set; }

        public void Finalize(int userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
    }
}