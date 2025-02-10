using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{

    /// <summary>
    /// Contains unit tests for the Sale entity class.
    /// Tests cover adding items, price calculations, and status updates.
    /// </summary>
    public class SaleTests
    {
        [Fact(DisplayName = "Sale should initialize with default values")]
        public void Given_NewSale_When_Created_Then_ShouldHaveDefaultValues()
        {
            // Arrange & Act
            var sale = new Sale();

            // Assert
            Assert.NotEqual(Guid.Empty, sale.Id);
            Assert.Equal(ESaleStatus.Pending, sale.Status);
            Assert.NotNull(sale.Items);
            Assert.Equal(0, sale.TotalPrice);
        }

        [Fact(DisplayName = "Adding an item should update total price")]
        public void Given_Sale_When_AddingItem_Then_TotalPriceShouldBeUpdated()
        {
            // Arrange
            var sale = new Sale();
            var item = new SaleItem { ProductId = Guid.NewGuid(), Quantity = 5, UnitPrice = 10 };

            // Act
            sale.AddItem(item);

            // Assert
            Assert.Single(sale.Items);
            Assert.Equal(45, sale.TotalPrice); // 10% discount applied
        }

        [Fact(DisplayName = "Updating status should change the sale's status")]
        public void Given_Sale_When_UpdatingStatus_Then_StatusShouldChange()
        {
            // Arrange
            var sale = new Sale();

            // Act
            sale.UpdateStatus(ESaleStatus.Completed);

            // Assert
            Assert.Equal(ESaleStatus.Completed, sale.Status);
            Assert.NotNull(sale.UpdatedAt);
        }
    }
}
