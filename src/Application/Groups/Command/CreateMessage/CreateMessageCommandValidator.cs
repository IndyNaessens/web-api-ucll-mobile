using FluentValidation;

namespace Application.Groups.Command.CreateMessage
{
    public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageCommandValidator()
        {
            // content
            RuleFor(x => x.Content)
                .NotEmpty();
        }
    }
}