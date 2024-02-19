using Unicamente.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Unicamente.UI.Web.Models
{
    public class InvestidorViewModel
    {
        public int ID { get; set; }

        [RegularExpression("^[a-zA-Z\\u00C0-\\u017F\\s]+$", ErrorMessage ="Digite um nome válido")]
        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }
        public TipoPessoaViewModel TipoPessoa { get; set; }
        public SituacaoCadastroDTO SituacaoCadastro { get; set; }
        public ComplementoInvestidorViewModel Complemento{ get; set; }
    }
}
