using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.MemberEntity;
using MediatR;
using System.Linq;

namespace Application.Groups.Command.LeaveGroup
{
    public class LeaveGroupCommandHandler : IRequestHandler<LeaveGroupCommand>
    {
        private readonly IRepository _repository;

        public LeaveGroupCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(LeaveGroupCommand request, CancellationToken cancellationToken)
        {
            // get auth userid, later service
            var authUserId = request.UserId;
            
            // check if last member in the group
            if(_repository.Members.Count(m => m.GroupId == request.GroupId) == 1)
            {
                // delete the group and cascade all
                var group = new Group{ Id = request.GroupId };
                _repository.Groups.Remove(group);
            }
            else 
            {
                // just leave the group because other members exist
                var membership = new Member {UserId = authUserId, GroupId = request.GroupId};
                _repository.Members.Remove(membership);
            }

            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}