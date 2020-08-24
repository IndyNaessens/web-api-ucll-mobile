using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Query.GetJoinedGroups
{
    public class GetJoinedGroupsCommandHandler : IRequestHandler<GetJoinedGroupsCommand, List<JoinedGroupsModel>>
    {
        private readonly IRepository _repository;

        public GetJoinedGroupsCommandHandler(IRepository repository)
        {
            _repository = repository;
        } 
            
        public async Task<List<JoinedGroupsModel>> Handle(GetJoinedGroupsCommand request, CancellationToken cancellationToken)
        {
            // get auth userid, later with service
            var authUserId = request.UserId;
            
            // get an overview over groups that the user has joined
            return await _repository.Groups
                .Where(g => g.Memberships.Any(m => m.UserId == request.UserId))
                .Select(g => new JoinedGroupsModel(
                    g.Id, 
                    g.Name, 
                    g.CreationDate, 
                    g.Memberships.Count,
                    _repository.Members.FirstOrDefault(m => m.GroupId == g.Id && m.IsAdmin).User.UserName
                ))
                .ToListAsync(cancellationToken);
        }
    }
}