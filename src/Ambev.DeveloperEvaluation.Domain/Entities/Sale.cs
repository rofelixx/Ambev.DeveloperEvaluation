using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale entity in the system.
    /// </summary>
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Gets or sets the customer ID associated with the sale.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the branch where the sale was made.
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// Gets or sets the total price of the sale.
        /// </summary>
        public decimal TotalPrice { get; private set; }

        /// <summary>
        /// Gets or sets the status of the sale (e.g., "Pending", "Completed", etc.).
        /// </summary>
        public ESaleStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the list of sale items.
        /// </summary>
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();

        /// <summary>
        /// Gets or sets the date and time when the sale was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the sale was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Initializes a new instance of the Sale class.
        /// </summary>
        public Sale()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Status = ESaleStatus.Pending; // Default status
        }

        /// <summary>
        /// Adds an item to the sale and applies discounts.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        public void AddItem(SaleItem item)
        {
            // Apply the discount logic directly when adding the item
            item.ApplyDiscount();
            Items.Add(item);
            CalculateTotalPrice();
        }

        /// <summary>
        /// Calculates the total price for the sale based on the items.
        /// </summary>
        private void CalculateTotalPrice()
        {
            TotalPrice = Items.Sum(item => item.TotalPrice); // Use LINQ to sum up all item total prices
        }

        /// <summary>
        /// Updates the sale status.
        /// </summary>
        /// <param name="newStatus">The new status to be set.</param>
        public void UpdateStatus(ESaleStatus newStatus)
        {
            Status = newStatus;
            UpdatedAt = DateTime.UtcNow;
        }
    }

    /// <summary>
    /// Represents a sale item.
    /// </summary>
    public class SaleItem
    {
        /// <summary>
        /// Gets or sets the product ID associated with the sale item.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product being sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the total price of the item, including any discount.
        /// </summary>
        public decimal TotalPrice { get; private set; }

        /// <summary>
        /// Applies the discount to the item based on quantity.
        /// </summary>
        public void ApplyDiscount()
        {
            if (Quantity >= 10 && Quantity <= 20)
            {
                // 20% discount for quantities between 10 and 20
                TotalPrice = Quantity * UnitPrice * 0.80m;
            }
            else if (Quantity >= 4)
            {
                // 10% discount for quantities between 4 and 9
                TotalPrice = Quantity * UnitPrice * 0.90m;
            }
            else
            {
                // No discount for quantities below 4
                TotalPrice = Quantity * UnitPrice;
            }
        }
    }
}
