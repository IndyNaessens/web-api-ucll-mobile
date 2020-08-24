using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Exceptions.Group;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ShoppingTrips.Query.GetItems
{
    public class GetItemsCommandHandler : IRequestHandler<GetItemsCommand, List<ItemEntryModel>>
    {
        private readonly IRepository _repository;

        public GetItemsCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<ItemEntryModel>> Handle(GetItemsCommand request, CancellationToken cancellationToken)
        {
            // auth user id, later with service
            var authUserId = request.UserId;
            
            // only member of group can retrieve shopping trips
            if(! await _repository.IsMemberOfGroupAsync(authUserId,request.GroupId,cancellationToken))
                throw new UserNotMemberOfGroupException();
            
            // retrieve shopping trips of group
            return await _repository.Items
                .Where(s => s.ShoppingTripId == request.ShoppingTripId)
                .Select(s => new ItemEntryModel(
                    s.Id,
                    _repository.Users.FirstOrDefault(u => u.Id == s.MemberUserId).UserName,
                    s.Amount,
                    s.Name,
                    s.IsFresh,
                    s.Price
                ))
                .ToListAsync(cancellationToken);
        }
    }
}