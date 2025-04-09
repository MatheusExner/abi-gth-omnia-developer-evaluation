namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public interface IMessagePublisher
    {
        /// <summary>
        /// Publish a message to the message broker.
        /// The message will be serialized to JSON and sent to the specified routing key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="routingKey"></param>
        void Publish<T>(T message, string routingKey);
    }
}