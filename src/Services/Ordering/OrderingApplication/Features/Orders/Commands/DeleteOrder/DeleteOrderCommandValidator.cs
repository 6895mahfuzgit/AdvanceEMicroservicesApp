using FluentValidation;

namespace OrderingApplication.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.Id)
                   .NotEmpty()
                    .WithMessage("{Id} can't be empty.")
                   .NotNull()
                   .WithMessage("{Id} can't be null.")
                   .GreaterThan(0)
                   .WithMessage("{Id} should be greater than 0.");
        }
    }
}
