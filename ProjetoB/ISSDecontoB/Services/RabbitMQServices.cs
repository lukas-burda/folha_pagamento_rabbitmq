using ISSDecontoB.Application;
using ISSDecontoB.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSDecontoB.Services
{
    public class RabbitMQServices : IRabbitMQServices
    {
        public List<Folha> ConsumirQueue()
        {
            List<Folha> folhas = new List<Folha>();
            Folha folha = new();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "mensagem",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    folhas = this.ConsumirMessage(message);
                };

                channel.BasicConsume(queue: "mensagem",
                                     autoAck: true,
                                     consumer: consumer);
            }

            folhas.Add(folha);

            return folhas;
        }

        public List<Folha> ConsumirMessage(string mensagem)
        {
            return JsonConvert.DeserializeObject<List<Folha>>(mensagem);
        }
    }
}
