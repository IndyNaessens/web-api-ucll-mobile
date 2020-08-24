using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Command.FakeLogin
{
    public class FakeLoginCommand : IRequest<int>
    {
        private string _userName;
        public string UserName 
        { 
            get => _userName.ToLower();
            set => _userName = value ?? string.Empty;
        }
        public string Password { get; set; }
    }

    public class Handler : IRequestHandler<FakeLoginCommand, int>
    {
        private readonly IRepository _repository;

        public Handler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(FakeLoginCommand request, CancellationToken cancellationToken)
        {
            // get user
            // yeah yeah password in clear text
            // normally is use Identity with Identity Server but I don't have time for it as I work alone on this backend
            var userId = await _repository.Users
                .Where(u => u.UserName == request.UserName && u.Password == request.Password)
                .Select(u => u.Id)
                .FirstOrDefaultAsync(cancellationToken);

            return userId;
        }
    }

    public class Validator : AbstractValidator<FakeLoginCommand>
    {
        public Validator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(255);
        }
    }
}