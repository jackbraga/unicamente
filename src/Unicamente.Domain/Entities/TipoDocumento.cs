using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Domain.Entities
{
    public class TipoDocumento : BaseEntity
    {
        public string Descricao { get; set; }
        public string Sigla { get; set; }
    }
}
