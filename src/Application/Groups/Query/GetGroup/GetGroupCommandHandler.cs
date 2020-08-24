using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Interfaces;
using Application.Groups.Query.GetShoppingTrips;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Exceptions.Group;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Groups.Query.GetGroup
{
    public class GetGroupCommandHandler : IRequestHandler<GetGroupCommand, GroupModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetGroupCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GroupModel> Handle(GetGroupCommand request, CancellationToken cancellationToken)
        {
            // auth user id, later with service
            var authUserId = request.UserId;

            // only members can retrieve group details
            if (!await _repository.IsMemberOfGroupAsync(authUserId, request.GroupId, cancellationToken))
                throw new UserNotMemberOfGroupException();

            // query
            return await _repository.Groups
                .Where(g => g.Id == request.GroupId)
                .Select(g => new GroupModel
                {
                    GroupId = g.Id,
                    Name = g.Name,
                    CreationDate = g.CreationDate,
                    InviteCode = g.InviteCode,
                    Members = _repository.Users
                        .Where(u => u.Memberships.Any(m => m.GroupId == g.Id))
                        .Select(u => new UserDto
                                {
                                    UserId = u.Id,
                                    UserName = u.UserName,
                                    Status = u.Status,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName
                                })
                        .ToList(),
                    ShoppingTrips = _repository.ShoppingTrips
                        .Where(s => s.MemberGroupId == g.Id)
                        .Select(s => new ShoppingTripEntryModel(
                            s.Id,
                            _repository.Members.Include(m => m.User).FirstOrDefault(m => m.UserId == s.MemberUserId).User.UserName,
                            s.Name,
                            s.StartTime,
                            s.Transportation
                        ))
                        .ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}