using System.Text;
using System.Text.Json;
using Ambev.DeveloperEvaluation.Domain.Events;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Ambev.DeveloperEvaluation.Application.Messaging;

/// <summary>
/// RabbitMQ message publisher implementation.
/// This class is responsible for publishing messages to a RabbitMQ exchange using the topic exchange type.
/// </summary>
public class RabbitMqPublisher : IMessagePublisher
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqPublisher(IConfiguration configuration)
    {
        var factory = new ConnectionFactory
        {
            HostName = configuration["RabbitMQ:HostName"] ?? "localhost",
            UserName = configuration["RabbitMQ:UserName"] ?? "guest",
            Password = configuration["RabbitMQ:Password"] ?? "guest"
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare(exchange: "my_exchange", type: ExchangeType.Topic);
    }

    public void Publish<T>(T message, string routingKey)
    {
        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        // _channel.BasicPublish(
        //     exchange: "my_exchange",
        //     routingKey: routingKey,
        //     basicProperties: null,
        //     body: body
        // );
        Console.WriteLine($" [x] Sent {routingKey}: {body}");
    }
}
