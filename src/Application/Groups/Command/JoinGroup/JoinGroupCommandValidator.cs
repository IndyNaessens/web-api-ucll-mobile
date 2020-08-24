using FluentValidation;

namespace Application.Groups.Command.JoinGroup
{
    public class JoinGroupCommandValidator : AbstractValidator<JoinGroupCommand>
    {
        public JoinGroupCommandValidator()
        {
            // invite code
            RuleFor(x => x.InviteCode)
                .NotEmpty();
        }
    }
}