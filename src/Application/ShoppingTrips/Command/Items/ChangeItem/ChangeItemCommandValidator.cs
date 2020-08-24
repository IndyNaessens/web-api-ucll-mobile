using Application.Common.Dtos;
using Application.Common.Validators;
using FluentValidation;

namespace Application.ShoppingTrips.Command.Items.ChangeItem
{
    public class ChangeItemCommandValidator : AbstractValidator<ChangeItemCommand>
    {
        public ChangeItemCommandValidator()
        {
            RuleFor(x => x.UpdatedShoppingTripItem)
                .SetValidator(new ShoppingTripItemDtoValidator());
        }
    }
}