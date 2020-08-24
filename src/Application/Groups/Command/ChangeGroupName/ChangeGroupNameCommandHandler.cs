using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions.Group;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Groups.Command.ChangeGroupName
{
    public class ChangeGroupNameCommandHandler : IRequestHandler<ChangeGroupNameCommand>
    {
        private readonly IRepository _repository;

        public ChangeGroupNameCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ChangeGroupNameCommand request, CancellationToken cancellationToken)
        {
            // get authenticated userid, later on by service
            var authUserId = request.UserId;

            // member needs to be admin for changing the group name
            if (!await _repository.IsAdminOfGroupAsync(authUserId, request.GroupId, cancellationToken))
                throw new UserIsNotAdminOfGroupException();

            // attach group
            var group = new Group { Id = request.GroupId };
            _repository.Groups.Attach(group);
            
            // change name
            group.Name = request.Name;

            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}