using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Application.DTOs
{
    public class ComodoImovelDTO 
    {
        public int ID { get; set; }
        public int Quantidade { get; set; }
        public ComodoDTO Comodo { get; set; }
        public ImovelDTO Imovel { get; set; }
    }
}
