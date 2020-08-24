using FluentValidation;

namespace Application.Users.Command.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            // user name
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MaximumLength(255);
            
            // email
            RuleFor(x => x.Email)
                .MaximumLength(255)    
                .EmailAddress();
            
            // password
            RuleFor(x => x.Password)
                .MinimumLength(4)
                .MaximumLength(255)
                .Equal(x => x.PasswordConfirmation);
        }   
    }
}