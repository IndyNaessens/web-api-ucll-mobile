using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities.UserEntity;
using MediatR;

namespace Application.Users.Command.ChangeUserFullName
{
    public class ChangeUserFullNameHandler : IRequestHandler<ChangeUserFullNameCommand>
    {
        private readonly IRepository _repository;

        public ChangeUserFullNameHandler(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(ChangeUserFullNameCommand request, CancellationToken cancellationToken)
        {
            // get the auth user, later on use a auth service instead of trusting the request 
            var authenticatedUserId = request.UserId;
            
            // attach the user
            var user = new User {Id = authenticatedUserId};
            _repository.Users.Attach(user);
            
            // change properties
            user.FirstName = request.FistName;
            user.LastName = request.LastName;

            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}