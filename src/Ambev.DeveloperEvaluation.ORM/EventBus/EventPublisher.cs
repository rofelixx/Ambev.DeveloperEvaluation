namespace Ambev.DeveloperEvaluation.ORM.EventBus
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T eventMessage) where T : IEvent;
    }

    public class EventPublisher : IEventPublisher
    {
        public async Task PublishAsync<T>(T eventMessage) where T : IEvent
        {
            // Lógica de publicação de evento (por exemplo, enviar para uma fila ou mensagem)
            // Aqui você poderia usar uma biblioteca como RabbitMQ, Kafka, etc.

            Console.WriteLine($"Event Published: {eventMessage.GetType().Name}");
            await Task.CompletedTask;
        }
    }
}
