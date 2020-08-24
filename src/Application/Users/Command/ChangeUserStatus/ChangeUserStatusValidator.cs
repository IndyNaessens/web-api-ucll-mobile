using FluentValidation;

namespace Application.Users.Command.ChangeUserStatus
{
    public class ChangeUserStatusValidator : AbstractValidator<ChangeUserStatusCommand>
    {
        public ChangeUserStatusValidator()
        {
            // status validation:
            RuleFor(x => x.Status)
                .IsInEnum();
        }
    }
}