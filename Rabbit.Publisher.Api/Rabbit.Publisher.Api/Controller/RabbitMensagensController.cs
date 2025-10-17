using Microsoft.AspNetCore.Mvc;
using Rabbit.Models.Entities;
using Rabbit.Services.Interfaces;

namespace Rabbit.Publisher.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMensagensController : ControllerBase
    {
        private readonly IRabbitMensagemService _service;
        public RabbitMensagensController(IRabbitMensagemService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddMensagem(RabbitMensagem mensagem)
        {
            _service.SendMessagem(mensagem);
        }
    }
}
