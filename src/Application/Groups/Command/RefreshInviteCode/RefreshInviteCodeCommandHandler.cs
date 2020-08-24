using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions.Group;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Groups.Command.RefreshInviteCode
{
    public class RefreshInviteCodeCommandHandler : IRequestHandler<RefreshInviteCodeCommand, Guid>
    {
        private readonly IRepository _repository;

        public RefreshInviteCodeCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Guid> Handle(RefreshInviteCodeCommand request, CancellationToken cancellationToken)
        {
            // get the auth user id, later service
            var authUserId = request.UserId;
            
            // member needs to be admin for refreshing the invite code
            if(! await _repository.IsAdminOfGroupAsync(authUserId, request.GroupId, cancellationToken))
                throw new UserIsNotAdminOfGroupException();
            
            // attach group
            var group = new Group { Id = request.GroupId };
            _repository.Groups.Attach(group);
            
            // refresh invite code
            group.InviteCode = Guid.NewGuid();

            await _repository.SaveChangesAsync(cancellationToken);
            return group.InviteCode;
        }
    }
}