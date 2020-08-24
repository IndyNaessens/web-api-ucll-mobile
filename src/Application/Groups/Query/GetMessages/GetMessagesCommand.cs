using System.Collections.Generic;
using MediatR;

namespace Application.Groups.Query.GetMessages
{
    public class GetMessagesCommand : IRequest<List<MessageModel>>
    {
        public int UserId { get; }
        public int GroupId { get; }

        public GetMessagesCommand(int userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
    }
}