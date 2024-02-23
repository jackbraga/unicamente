using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Domain.Entities
{
    public class Vegetal : BaseEntity
    {
        public string Descricao { get; set; }

        public string MestrePreparo { get; set; }
        public DateTime DataPreparo { get; set; }
        public int IDMariri { get; set; }
        public int IDChacrona { get; set; }
        public string Observacao { get; set; }
        public byte[] Imagem { get; set; }
    }
}
