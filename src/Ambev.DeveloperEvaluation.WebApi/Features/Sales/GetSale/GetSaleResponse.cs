using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleResponse
    {
        /// <summary>
        /// Gets or sets the ID of the sale.
        /// </summary>
        public Guid SaleId { get; set; }

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
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale (e.g., "Pending", "Completed", etc.).
        /// </summary>
        public ESaleStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the sale was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the sale was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the list of sale items.
        /// </summary>
        public List<SaleItemResponse> Items { get; set; }

        public GetSaleResponse(Sale sale)
        {
            SaleId = sale.Id;
            CustomerId = sale.CustomerId;
            Branch = sale.Branch;
            TotalPrice = sale.TotalPrice;
            Status = sale.Status;
            CreatedAt = sale.CreatedAt;
            UpdatedAt = sale.UpdatedAt;
            Items = sale.Items.Select(item => new SaleItemResponse(item)).ToList();
        }
    }

    public class SaleItemResponse
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
        public decimal TotalPrice { get; set; }

        public SaleItemResponse(SaleItem item)
        {
            ProductId = item.ProductId;
            Quantity = item.Quantity;
            UnitPrice = item.UnitPrice;
            TotalPrice = item.TotalPrice;
        }
    }
}
