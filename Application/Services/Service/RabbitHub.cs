using Application.Services.ServiceInterface;
using System.Text;
using RabbitMQ.Client;

namespace Application.Services.Service
{
    public class RabbitHub : IRabbitHub
    {
        public async void start()
        {
            //ConnectionFactory factory = new ConnectionFactory();
            //factory.UserName = "guest";
            //factory.Password = "guest";
            //factory.VirtualHost = "guest";
            //factory.HostName = "guest";
            //IConnection conn = await factory.CreateConnectionAsync();


            //IChannel channel = await conn.CreateChannelAsync();

            //channel.QueueDeclareAsync(queue: "test-queue",
            //    durable: false,
            //    exclusive: false,
            //    autoDelete: false,
            //    arguments: null);

            //string message = "Hello from .NET to RabbitMQ in Docker!";
            //var body = Encoding.UTF8.GetBytes(message);

            //channel.BasicPublishAsync(exchange: "",
            //    routingKey: "test-queue",
            //    basicProperties: null,

            //    );

            //Console.WriteLine($"[x] Sent: {message}");

            throw new NotImplementedException();
        }
    }
}
