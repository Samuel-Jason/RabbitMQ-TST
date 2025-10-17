using Rabbit.Models.Entities;

namespace Rabbit.Services.Interfaces
{
    public interface IRabbitMensagemService
    {
        void SendMessagem(RabbitMensagem mensagem);
    }
}
