using FluentValidation;

namespace Application.Groups.Command.ChangeGroupName
{
    public class ChangeGroupNameCommandValidator : AbstractValidator<ChangeGroupNameCommand>
    {
        public ChangeGroupNameCommandValidator()
        {
            // group name
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}