using Application.Common.Dtos;
using FluentValidation;

namespace Application.Common.Validators
{
    public class ShoppingTripItemDtoValidator : AbstractValidator<ShoppingTripItemDto>
    {
        public ShoppingTripItemDtoValidator()
        {
            // name
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);

            // amount
            RuleFor(x => x.Amount)
                .NotEmpty()
                .LessThanOrEqualTo(1000);

            // price
            RuleFor(x => x.Price)
                .NotEmpty()
                .LessThanOrEqualTo(1_000_000);

            // image url (photo of product)
            RuleFor(x => x.ImageUrl)
                .MaximumLength(500);
        }
    }
}