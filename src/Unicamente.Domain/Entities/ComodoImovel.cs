using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Domain.Entities
{
    public class ComodoImovel :BaseEntity
    {
        public int Quantidade { get; set; }
        public Comodo Comodo { get; set; }
        public Imovel Imovel { get; set; }
    }
}
