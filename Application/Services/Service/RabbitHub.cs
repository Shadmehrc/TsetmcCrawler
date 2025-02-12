using Application.Services.ServiceInterface;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Application.Services.Service
{
    public class RabbitHub : IRabbitHub
    {
        public async void SendMessage()
        {

            var factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "Test Crawler", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;


            string message = "My second Message";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: string.Empty, routingKey: "Test Crawler", body: body);
        }

        //public void ReceiveMessage()
        //{
        //    var factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
        //    using var connection =  factory.CreateConnection();
        //    using var channel = connection.CreateModel();

        //     channel.QueueDeclare(queue: "Test Crawler", durable: false, exclusive: false, autoDelete: false, arguments: null);

        //     Console.WriteLine(" [*] Waiting for messages.");

        //     var consumer = new EventingBasicConsumer(channel);
        //     consumer.Received += (model, ea) =>
        //     {
        //         var body = ea.Body.ToArray();
        //         var message = Encoding.UTF8.GetString(body);
        //         Console.WriteLine($" [x] Received {message}");
        //     };
        //      channel.BasicConsume("Test Crawler", autoAck: true, consumer: consumer);


        //}



    }
}
