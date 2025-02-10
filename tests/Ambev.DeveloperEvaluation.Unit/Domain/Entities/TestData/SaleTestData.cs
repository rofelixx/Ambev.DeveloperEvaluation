using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Provides test data for Sale entity unit tests.
    /// </summary>
    public static class SaleTestData
    {
        /// <summary>
        /// Generates a valid Sale instance with default values.
        /// </summary>
        public static Sale GenerateValidSale()
        {
            var sale = new Sale
            {
                CustomerId = Guid.NewGuid(),
                Branch = "Main Branch",
                Status = ESaleStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                Items = new List<SaleItem>
                {
                    new SaleItem
                    {
                        ProductId = Guid.NewGuid(),
                        Quantity = 5,
                        UnitPrice = 10.0m
                    },
                    new SaleItem
                    {
                        ProductId = Guid.NewGuid(),
                        Quantity = 12,
                        UnitPrice = 15.0m
                    }
                }
            };

            // Apply discount and calculate total price
            foreach (var item in sale.Items)
            {
                item.ApplyDiscount();
            }

            return sale;
        }

        /// <summary>
        /// Generates a Sale instance with no items (invalid case).
        /// </summary>
        public static Sale GenerateSaleWithNoItems()
        {
            return new Sale
            {
                CustomerId = Guid.NewGuid(),
                Branch = "No Items Branch",
                Status = ESaleStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                Items = new List<SaleItem>()
            };
        }

        /// <summary>
        /// Generates a completed Sale instance.
        /// </summary>
        public static Sale GenerateCompletedSale()
        {
            var sale = GenerateValidSale();
            sale.UpdateStatus(ESaleStatus.Completed);
            return sale;
        }

        /// <summary>
        /// Generates a canceled Sale instance.
        /// </summary>
        public static Sale GenerateCanceledSale()
        {
            var sale = GenerateValidSale();
            sale.UpdateStatus(ESaleStatus.Canceled);
            return sale;
        }
    }
}