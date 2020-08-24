using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.UserEntity;
using Domain.Exceptions.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        
        public CreateUserCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // check if user does not exist already
            if (await _repository.Users.AnyAsync(u => u.Email == request.Email || u.UserName == request.UserName))
                throw new UserAlreadyExistsException();
            
            // map user, set defaults, and add user
            var user = _mapper.Map<User>(request);
            user.Status = Status.Offline;
            _repository.Users.Add(user);
            
            // save changes
            await _repository.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}