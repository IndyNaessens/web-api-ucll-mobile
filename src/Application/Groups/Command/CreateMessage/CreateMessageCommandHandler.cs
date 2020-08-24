using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities.MemberEntity;
using Domain.Exceptions.Group;
using MediatR;

namespace Application.Groups.Command.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, int>
    {
        private readonly IRepository _repository;

        public CreateMessageCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            // auth user id, later service
            var authUserId = request.UserId;
            
            // needs to be member of group to send message
            if (!await _repository.IsMemberOfGroupAsync(authUserId, request.GroupId, cancellationToken))
                throw new UserNotMemberOfGroupException();

            // attach member
            var member = new Member{UserId = authUserId, GroupId = request.GroupId};
            _repository.Members.Attach(member);
            
            // new message from member 
            var message = new Message {Content = request.Content};
            member.Messages.Add(message);
            
            await _repository.SaveChangesAsync(cancellationToken);
            return message.Id;
        }
    }
}