using FluentValidation;

namespace Application.Users.Command.ChangeUserFullName
{
    public class ChangeUserFullNameValidator : AbstractValidator<ChangeUserFullNameCommand>
    {
        public ChangeUserFullNameValidator()
        {
            // name validation:
            RuleFor(x => x.FistName)
                .NotEmpty()
                .MaximumLength(255);
            
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}