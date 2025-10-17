using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Models.Entities
{
    public class RabbitMensagem
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Texto { get; set; }
    }
}
