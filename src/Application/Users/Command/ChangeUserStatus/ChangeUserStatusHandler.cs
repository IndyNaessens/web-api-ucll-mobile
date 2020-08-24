using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities.UserEntity;
using MediatR;

namespace Application.Users.Command.ChangeUserStatus
{
    public class ChangeUserStatusHandler : IRequestHandler<ChangeUserStatusCommand>
    {
        private readonly IRepository _repository;

        public ChangeUserStatusHandler(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(ChangeUserStatusCommand request, CancellationToken cancellationToken)
        {
            // get the authenticated user later on user auth service
            var authenticatedUserId = request.UserId;
                
            // attach the user
            var user = new User {Id = authenticatedUserId};
            _repository.Users.Attach(user);
            
            // change properties
            user.Status = request.Status;

            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}