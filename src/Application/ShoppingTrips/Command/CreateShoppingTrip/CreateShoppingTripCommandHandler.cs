using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities.MemberEntity;
using Domain.Entities.ShoppingTripEntity;
using Domain.Exceptions.Group;
using MediatR;

namespace Application.ShoppingTrips.Command.CreateShoppingTrip
{
    public class CreateShoppingTripCommandHandler : IRequestHandler<CreateShoppingTripCommand, int>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateShoppingTripCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(CreateShoppingTripCommand request, CancellationToken cancellationToken)
        {
            // auth user id, later with service
            var authUserId = request.UserId;
            
            // map shopping trip
            var shoppingTrip = _mapper.Map<ShoppingTrip>(request);
            
            // only member of group can create shopping trip
            if(! await _repository.IsMemberOfGroupAsync(authUserId, request.GroupId, cancellationToken))
                throw new UserNotMemberOfGroupException();
            ;
            // attach member
            var member = new Member {UserId = authUserId, GroupId = request.GroupId};
            _repository.Members.Attach(member);
            
            // member creates shopping trip
            member.ShoppingTrips.Add(shoppingTrip);

            await _repository.SaveChangesAsync(cancellationToken);
            return shoppingTrip.Id;
        }    
    }
}