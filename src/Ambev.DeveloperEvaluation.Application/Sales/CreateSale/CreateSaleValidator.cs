using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Validators
{
    /// <summary>
    /// Validator for CreateSaleCommand.
    /// </summary>
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            // Validate CustomerId
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID cannot be empty.");

            // Validate Branch
            RuleFor(x => x.Branch)
                .NotEmpty().WithMessage("Branch cannot be empty.")
                .MaximumLength(100).WithMessage("Branch cannot exceed 100 characters.");

            // Validate TotalPrice
            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("Total price must be greater than zero.");

            // Validate Status
            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status must be a valid sale status.");

            // Validate Items
            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("Sale must have at least one item.");

            // Validate each item in Items list
            RuleForEach(x => x.Items).SetValidator(new CreateSaleItemValidator());
        }
    }

    /// <summary>
    /// Validator for CreateSaleItemCommand.
    /// </summary>
    public class CreateSaleItemValidator : AbstractValidator<CreateSaleItemCommand>
    {
        public CreateSaleItemValidator()
        {
            // Validate ProductId
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID cannot be empty.");

            // Validate Quantity
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .LessThanOrEqualTo(20).WithMessage("You cannot sell more than 20 identical items.");

            // Validate UnitPrice
            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Unit price must be greater than zero.");
        }
    }
}
