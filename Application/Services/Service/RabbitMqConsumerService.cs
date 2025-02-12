using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Application.Services.Service
{
    public class RabbitMqConsumerService : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly string _queueName = "Test Crawler";
        private List<string> _receivedMessage = new List<string>();

        public RabbitMqConsumerService()
        {
            var factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: _queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Consumer is here");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[✔] Received: {message}");
            };

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[✔] Received: {message}");

                _receivedMessage.Add(message);
            };


            _channel.BasicConsume(queue: _queueName,
                autoAck: true,
                consumer: consumer);


            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
