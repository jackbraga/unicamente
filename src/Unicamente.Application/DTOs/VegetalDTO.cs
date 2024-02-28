using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Application.DTOs
{
    public class VegetalDTO
    {
        public int ID { get; set; }
        public string Descricao { get; set; }

        public string MestrePreparo { get; set; }
        public DateTime DataPreparo { get; set; }

        public MaririDTO Mariri { get; set; }

        public ChacronaDTO Chacrona { get; set; }
        //public int IDMariri { get; set; }
        //public int IDChacrona { get; set; }
        public string Observacao { get; set; }
        public byte[] Imagem { get; set; }
    }
}
