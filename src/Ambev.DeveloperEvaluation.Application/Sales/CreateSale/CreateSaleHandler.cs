using Ambev.DeveloperEvaluation.Application.Sales.Events;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.EventBus;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IEventPublisher _eventPublisher;

        public CreateSaleHandler(ISaleRepository saleRepository, IEventPublisher eventPublisher)
        {
            _saleRepository = saleRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new Sale
            {
                CustomerId = request.CustomerId,
                Branch = request.Branch,
                CreatedAt = DateTime.UtcNow
            };

            foreach (var itemCommand in request.Items)
            {
                var item = new SaleItem
                {
                    ProductId = itemCommand.ProductId,
                    Quantity = itemCommand.Quantity,
                    UnitPrice = itemCommand.UnitPrice
                };

                // Apply discount logic and add the item to the sale
                sale.AddItem(item);
            }

            // Persist the sale
            await _saleRepository.CreateAsync(sale, cancellationToken);

            // Add event to created sale
            var saleCreatedEvent = new SaleCreatedEvent(sale.Id, sale.CustomerId, sale.Branch, sale.TotalPrice, sale.CreatedAt);
            await _eventPublisher.PublishAsync(saleCreatedEvent);

            return new CreateSaleResult(sale);
        }
    }
}
