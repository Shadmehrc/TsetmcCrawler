using Application.Services.ServiceInterface;
using System.Text;
using RabbitMQ.Client;

namespace Application.Services.Service
{
    public class RabbitHub : IRabbitHub
    {
        public async void start()
        {

            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection =  factory.CreateConnection();
            using var channel =  connection.CreateModel();

             channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false,
                arguments: null);
            
            string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);

             channel.BasicPublish(exchange: string.Empty, routingKey: "hello", body: body);
            Console.WriteLine($" [x] Sent {message}");

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();




            //    ConnectionFactory factory = new ConnectionFactory();
            //    factory.UserName = "guest";
            //    factory.Password = "guest";
            //    factory.VirtualHost = "guest";
            //    factory.HostName = "guest";
            //    IConnection conn = await factory.CreateConnectionAsync();


            //    IChannel channel = await conn.CreateChannelAsync();

            //    channel.QueueDeclareAsync(queue: "test-queue",
            //        durable: false,
            //        exclusive: false,
            //        autoDelete: false,
            //        arguments: null);

            //    string message = "Hello from .NET to RabbitMQ in Docker!";
            //    var body = Encoding.UTF8.GetBytes(message);

            //    channel.BasicPublishAsync(exchange: "",
            //        routingKey: "test-queue",
            //        basicProperties: null,

            //        );

            //    Console.WriteLine($"[x] Sent: {message}");

            throw new NotImplementedException();
        }
    }
}
