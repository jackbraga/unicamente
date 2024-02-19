using Unicamente.Repository.Uteis;
using System.ComponentModel.DataAnnotations;

namespace Unicamente.Domain.Entities
{
    public class ComplementoInvestidor: BaseEntity
    {
        public string CPF { get; set; }
        public string RG { get; set; }
        public string OrgaoExpedidor { get; set; }
        public string UFRG { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public DateTime Nascimento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int IDInvestidor { get; set; }

        public void ValidarDominio()
        {


            ValidarDados validarDados = new ValidarDados();


            if (!validarDados.CPF(CPF))
            {
                throw new Exception("O CPF informado não é válido");
            }


            if (!validarDados.DataNascimento(Nascimento.ToString("dd/MM/yyyy"), 150, 16))
            {
                throw new Exception("Data de nascimento não é valida");
            }

        }
    }
}
