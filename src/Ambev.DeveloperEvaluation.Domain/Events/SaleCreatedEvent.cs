namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCreatedEvent : IEvent
    {
        public Guid SaleId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }

        public SaleCreatedEvent(Guid saleId, Guid customerId, decimal totalPrice, DateTime createdAt)
        {
            SaleId = saleId;
            CustomerId = customerId;
            TotalPrice = totalPrice;
            CreatedAt = createdAt;
        }
    }
}
