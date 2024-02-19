using System.ComponentModel.DataAnnotations;

namespace Unicamente.UI.Web.Models
{
    public class ComplementoInvestidorViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string CPF { get; set; }
        public string RG { get; set; }
        public string OrgaoExpedidor { get; set; }
        public string UFRG { get; set; }

        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [MaxLength(10, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O {0} deve ter no mínimo {1} caracteres")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int IDInvestidor { get; set; }

    }
}
