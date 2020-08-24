using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities.ShoppingTripEntity;
using Domain.Exceptions.ShoppingTrip;
using MediatR;

namespace Application.ShoppingTrips.Command.CancelShoppingTrip
{
    public class CancelShoppingTripCommandHandler : IRequestHandler<CancelShoppingTripCommand>
    {
        private readonly IRepository _repository;

        public CancelShoppingTripCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(CancelShoppingTripCommand request, CancellationToken cancellationToken)
        {
            // auth user id, later with service
            var authUserId = request.UserId;
            
            // check if the user is the creator of the shopping trip that exists in a group
            if(! await _repository.IsCreatorOfShoppingTrip(authUserId, request.GroupId, request.ShoppingTripId, cancellationToken))
                throw new NotCreatorOfShoppingTripException();
            
            // remove shopping trip
            var shoppingTrip = new ShoppingTrip {Id = request.ShoppingTripId};
            _repository.ShoppingTrips.Remove(shoppingTrip);

            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}