using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Exceptions.Group;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Groups.Query.GetMessages
{
    public class GetMessagesCommandHandler : IRequestHandler<GetMessagesCommand, List<MessageModel>>
    {
        private readonly IRepository _repository;

        public GetMessagesCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<MessageModel>> Handle(GetMessagesCommand request, CancellationToken cancellationToken)
        {
            // auth user id, later service
            var authUserId = request.UserId;

            // needs to be member to read group messages
            if (!await _repository.IsMemberOfGroupAsync(authUserId, request.GroupId, cancellationToken))
                throw new UserNotMemberOfGroupException();
            
            // get all messages if member exist
            return await _repository.Messages
                .Include(m => m.Member)
                    .ThenInclude(m => m.User)
                .Where(m => m.MemberGroupId == request.GroupId)
                .Select(m => new MessageModel(m.Member.User.UserName, m.Content, m.SendAt))
                .ToListAsync(cancellationToken);
        }
    }
}