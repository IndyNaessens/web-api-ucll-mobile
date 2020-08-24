using System.Data;
using FluentValidation;

namespace Application.Groups.Command.CreateGroup
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            // group name
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}