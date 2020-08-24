using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities.MemberEntity;
using Domain.Exceptions.Group;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Groups.Command.JoinGroup
{
    public class JoinGroupCommandHandler : IRequestHandler<JoinGroupCommand, int>
    {
        private readonly IRepository _repository;

        public JoinGroupCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<int> Handle(JoinGroupCommand request, CancellationToken cancellationToken)
        {
            // get the auth user, later with service
            var authUserId = request.UserId;
            
            // find the group with the invite code
            var group = await _repository.Groups
                .FirstOrDefaultAsync(g => g.InviteCode == request.InviteCode, cancellationToken);
            
            // group not found so invalid invite code
            if (group == null) throw new InvalidInviteCodeException();
            
            // join the group
            group.Memberships.Add(new Member{UserId = authUserId});

            await _repository.SaveChangesAsync(cancellationToken);
            return group.Id;
        }
    }
}