using System;
using Domain.Entities;
using MediatR;

namespace Application.Users.Command.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        // backing fields
        private string _username;
        private string _email;

        public string UserName
        {
            get => _username.ToLower();
            set => _username = value ?? string.Empty;
        }
        
        public string Email
        {
            get => _email.ToLower();
            set => _email = value ?? string.Empty;
        }
        
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        
    }
}