using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Domain.Entities
{
    public class Mariri : BaseEntity
    {
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public byte[] Imagem { get; set; }
    }
}
