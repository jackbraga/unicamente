using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Application.DTOs
{
    public class ChacronaDTO
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public byte[] Imagem { get; set; }
    }
}
