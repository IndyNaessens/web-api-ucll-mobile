using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities.ShoppingTripEntity;
using Domain.Exceptions.ShoppingTrip;
using MediatR;

namespace Application.ShoppingTrips.Command.ChangeShoppingTripPlanning
{
    public class ChangeShoppingTripPlanningCommandHandler : IRequestHandler<ChangeShoppingTripPlanningCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ChangeShoppingTripPlanningCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(ChangeShoppingTripPlanningCommand request, CancellationToken cancellationToken)
        {
            // auth user id, later with service
            var authUserId = request.UserId;
            
            // check if the user is the creator of the shopping trip that exists in a group
            if(! await _repository.IsCreatorOfShoppingTrip(authUserId, request.GroupId, request.ShoppingTripId, cancellationToken))
                throw new NotCreatorOfShoppingTripException();
            
            // attach shopping trip with location
            var shoppingTrip = new ShoppingTrip {Id = request.ShoppingTripId, Location = new Location{ShoppingTripId = request.ShoppingTripId}};
            _repository.ShoppingTrips.Attach(shoppingTrip);
            
            // change information shopping trip
            shoppingTrip.StartTime = request.StartTime;
            shoppingTrip.Transportation = request.Transportation;
            shoppingTrip.Location = _mapper.Map<Location>(request.Location);

            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}