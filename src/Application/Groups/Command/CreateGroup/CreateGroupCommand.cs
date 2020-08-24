using Domain.Entities;
using MediatR;

namespace Application.Groups.Command.CreateGroup
{
    public class CreateGroupCommand : IRequest<int>
    {
        public int UserId { get; private set; }
        public string Name { get; set; }

        public void Finalize(int userId) => UserId = userId;
    }
}