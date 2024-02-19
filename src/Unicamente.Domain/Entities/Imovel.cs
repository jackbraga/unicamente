using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Domain.Entities
{
    public class Imovel : BaseEntity
    {
        public string Descricao { get; set; }
        public decimal Metragem { get; set; }
        public TipoImovel TipoImovel { get; set; }

    }
}
