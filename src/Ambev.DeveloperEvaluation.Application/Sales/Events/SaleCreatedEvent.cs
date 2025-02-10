namespace Ambev.DeveloperEvaluation.Application.Sales.Events
{
    public class SaleCreatedEvent: IEvent
    {
        public Guid SaleId { get; set; }
        public Guid CustomerId { get; set; }
        public string Branch { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }

        public SaleCreatedEvent(Guid saleId, Guid customerId, string branch, decimal totalPrice, DateTime createdAt)
        {
            SaleId = saleId;
            CustomerId = customerId;
            Branch = branch;
            TotalPrice = totalPrice;
            CreatedAt = createdAt;
        }
    }
}
