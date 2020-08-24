using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities.ShoppingTripEntity;
using Domain.Exceptions.ShoppingTrip;
using MediatR;

namespace Application.ShoppingTrips.Command.Items.ChangeItem
{
    public class ChangeItemCommandHandler : IRequestHandler<ChangeItemCommand>
    {
        private readonly IRepository _repository;

        public ChangeItemCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(ChangeItemCommand request, CancellationToken cancellationToken)
        {
            // auth user id, later with service
            var authUserId = request.UserId;
            
            // only member that created the item can remove it
            if (!await _repository.CanAlterShoppingTripItem(authUserId, request.GroupId, request.ShoppingTripId,
                request.ShoppingTripItemId, cancellationToken))
                throw new NotCreatorOfShoppingTripItemException();
            
            // attach shoppingTripItem
            var item = new ShoppingTripItem {Id = request.ShoppingTripItemId};
            _repository.Items.Attach(item); // sure we can map and do update to mark it dirty but whatever
            
            // update props
            item.Name = request.UpdatedShoppingTripItem.Name;
            item.Amount = request.UpdatedShoppingTripItem.Amount;
            item.IsFresh = request.UpdatedShoppingTripItem.IsFresh;
            item.Price = request.UpdatedShoppingTripItem.Price;
            item.ImageUrl = request.UpdatedShoppingTripItem.ImageUrl;

            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}