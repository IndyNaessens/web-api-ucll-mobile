using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Exceptions.ShoppingTrip;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ShoppingTrips.Query.GetShoppingTrip
{
    public class GetShoppingTripCommandHandler : IRequestHandler<GetShoppingTripCommand, ShoppingTripModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetShoppingTripCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<ShoppingTripModel> Handle(GetShoppingTripCommand request, CancellationToken cancellationToken)
        {
            // auth user id, later with service
            var authUserId = request.UserId;
            
            // only valid members that are in the same group as the shopping trip can access it
            if(! await _repository.HasAccessToShoppingTrip(authUserId, request.ShoppingTripId, cancellationToken))
                throw new NoAccessToShoppingTripException();
            
            // get shopping trip details (expensive)
            return await _repository.ShoppingTrips
                .Include(s => s.Location)
                .Include(s => s.Items)
                .Where(s => s.Id == request.ShoppingTripId)
                .Select(s => new ShoppingTripModel(
                    _repository.Users.FirstOrDefault(u => u.Id == s.MemberUserId).UserName,
                    s.Name,
                    s.Reason,
                    s.StartTime,
                    s.Transportation,
                    _mapper.Map<LocationDto>(s.Location),
                    s.Items.Select(item => new ShoppingTripItemModel(
                        _repository.Users.FirstOrDefault(u => u.Id == item.MemberUserId).UserName,
                        item.Name,
                        item.Amount,
                        item.IsFresh,
                        item.Price,
                        item.ImageUrl
                    )).ToList()
                ))
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}