using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities.ShoppingTripEntity;
using Domain.Exceptions.ShoppingTrip;
using MediatR;

namespace Application.ShoppingTrips.Command.Items.AddItem
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, int>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddItemCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            // auth user id, later with service
            var authUserId = request.UserId;

            // only valid members can add items to a shopping trip
            if (!await _repository.HasAccessToShoppingTrip(authUserId, request.ShoppingTripId, cancellationToken))
                throw new NoAccessToShoppingTripException();

            // attach shopping trip
            var shoppingTrip = new ShoppingTrip { Id = request.ShoppingTripId };
            _repository.ShoppingTrips.Attach(shoppingTrip);

            // map to shopping trip item and add to trip
            var shoppingTripItem = _mapper.Map<ShoppingTripItem>(request);
            shoppingTrip.Items.Add(shoppingTripItem);

            await _repository.SaveChangesAsync(cancellationToken);
            return shoppingTripItem.Id;
        }
    }
}
