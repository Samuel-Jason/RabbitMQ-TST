using Rabbit.Models.Entities;
using Rabbit.Repositories.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Rabbit.Repositories
{
    public class RabbitMensagemRepository : IRabbitMensagemRepository
    {
        private readonly ConnectionFactory _factory;

        public RabbitMensagemRepository()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"
            };
        }

        public void SendMessagem(RabbitMensagem mensagem)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            const string queueName = "rabbitMensagesQueue";

            channel.QueueDeclare(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var messageJson = JsonSerializer.Serialize(mensagem);
            var body = Encoding.UTF8.GetBytes(messageJson);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(
                exchange: "",
                routingKey: queueName,
                basicProperties: properties,
                body: body);

            Console.WriteLine($" [x] Mensagem enviada para fila: {queueName} - Título: {mensagem.Titulo}");
        }
    }
}
