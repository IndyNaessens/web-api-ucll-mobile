using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Exceptions.Group;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Groups.Query.GetShoppingTrips
{
    public class GetShoppingTripsCommandHandler : IRequestHandler<GetShoppingTripsCommand, List<ShoppingTripEntryModel>>
    {
        private readonly IRepository _repository;

        public GetShoppingTripsCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<ShoppingTripEntryModel>> Handle(GetShoppingTripsCommand request, CancellationToken cancellationToken)
        {
            // auth user id, later with service
            var authUserId = request.UserId;
            
            // only member of group can retrieve shopping trips
            if(! await _repository.IsMemberOfGroupAsync(authUserId,request.GroupId,cancellationToken))
                throw new UserNotMemberOfGroupException();
            
            // retrieve shopping trips of group
            return await _repository.ShoppingTrips
                .Where(s => s.MemberGroupId == request.GroupId)
                .Select(s => new ShoppingTripEntryModel(
                    s.Id,
                    _repository.Users.FirstOrDefault(u => u.Id == s.MemberUserId).UserName,
                    s.Name,
                    s.StartTime,
                    s.Transportation
                ))
                .ToListAsync(cancellationToken);
        }
    }
}