using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            // Validation for the sale request properties
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            // Validate each item individually
            RuleForEach(x => x.Items).SetValidator(new CreateSaleItemRequestValidator());

            // Check the rule for a maximum of 20 items per product
            RuleFor(x => x.Items)
                .Must(HaveLessThanOrEqualTo20Items).WithMessage("It's not possible to sell above 20 identical items.");
        }

        private bool HaveLessThanOrEqualTo20Items(List<CreateSaleItemRequest> items)
        {
            // Group items by ProductId and check the total quantity for each product
            var groupedItems = items.GroupBy(item => item.ProductId);
            foreach (var group in groupedItems)
            {
                // If the sum of quantities for any product exceeds 20, return false
                if (group.Sum(item => item.Quantity) > 20)
                    return false;
            }
            return true;
        }
    }

    public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
    {
        public CreateSaleItemRequestValidator()
        {
            // Validation for ProductId (it cannot be empty or invalid)
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID is required.");

            // Validation for the quantity of each item
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

            // Validation for the unit price of each item
            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Unit Price must be greater than zero.");
        }
    }
}
