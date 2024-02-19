using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Domain.Entities
{
    public class Corretor : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Contato { get; set; }
        public SituacaoCadastro SituacaoCadastro { get; set; }
    }
}
