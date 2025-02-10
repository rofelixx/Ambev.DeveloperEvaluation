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
            // Event publishing logic (e.g., send to a queue or message broker)
            // Here you could use a library like RabbitMQ, Kafka, etc.

            // Log the event publication with the timestamp
            Console.WriteLine($"Event Published: {eventMessage.GetType().Name} at {DateTime.UtcNow}");
            await Task.CompletedTask;

            // Simulating asynchronous event publishing (e.g., sending to a message queue)
            await Task.Delay(100); // Simulating the delay for communication with the message queue

            // Depending on the technology, you can use specific messaging APIs to send events.
            // Example:
            // _messageQueue.SendMessage(eventMessage);
        }
    }
}
