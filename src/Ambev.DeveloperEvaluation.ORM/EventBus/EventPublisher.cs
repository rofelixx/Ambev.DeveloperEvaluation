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
            // Aqui você pode adicionar a lógica para publicar eventos para uma fila de mensagens (RabbitMQ, Kafka, etc.)
            // Para simplicidade, estamos apenas simulando com um log.

            Console.WriteLine($"Event Published: {eventMessage.GetType().Name} at {DateTime.UtcNow}");

            // Simulação de envio de evento assíncrono
            await Task.Delay(100); // Simulando o atraso de comunicação com a fila

            // Dependendo da tecnologia, você pode usar APIs específicas de mensageria para enviar eventos.
            // Exemplo:
            // _messageQueue.SendMessage(eventMessage);
        }
    }
}
