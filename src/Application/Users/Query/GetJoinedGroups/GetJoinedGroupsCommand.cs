using System.Collections.Generic;
using MediatR;

namespace Application.Users.Query.GetJoinedGroups
{
    public class GetJoinedGroupsCommand : IRequest<List<JoinedGroupsModel>>
    {
        public int UserId { get; }

        public GetJoinedGroupsCommand(int userId) => UserId = userId;
    }
}