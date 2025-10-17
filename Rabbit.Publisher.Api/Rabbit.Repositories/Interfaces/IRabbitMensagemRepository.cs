using Rabbit.Models.Entities;

namespace Rabbit.Repositories.Interfaces
{
    public interface IRabbitMensagemRepository
    {
        void SendMessagem(RabbitMensagem mensagem);
    }
}
