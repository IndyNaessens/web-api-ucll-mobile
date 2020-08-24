using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities.ShoppingTripEntity;
using Domain.Exceptions.ShoppingTrip;
using MediatR;

namespace Application.ShoppingTrips.Command.Items.RemoveItem
{
    public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand>
    {
        private readonly IRepository _repository;

        public RemoveItemCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            // auth user id, later with service
            var authUserId = request.UserId;

            // only member that created the item can remove it
            if (!await _repository.CanAlterShoppingTripItem(authUserId, request.GroupId, request.ShoppingTripId,
                request.ItemId, cancellationToken))
                throw new NotCreatorOfShoppingTripItemException();

            // remove the item
            var shoppingTripItem = new ShoppingTripItem {Id = request.ItemId};
            _repository.Items.Remove(shoppingTripItem);

            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}