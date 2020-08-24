using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.MemberEntity;
using MediatR;

namespace Application.Groups.Command.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, int>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateGroupCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            // get auth user id, later from service
            var authUserId = request.UserId;
            
            // create group
            var group = _mapper.Map<Group>(request);
            _repository.Groups.Add(group);
            
            // add the admin
            var member = new Member
            {
                UserId = authUserId,
                IsAdmin = true
            };
            group.Memberships.Add(member);
            
            await _repository.SaveChangesAsync(cancellationToken);
            return group.Id;
        }
    }
}