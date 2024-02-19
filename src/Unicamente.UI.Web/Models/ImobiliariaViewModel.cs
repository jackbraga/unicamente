using System.ComponentModel.DataAnnotations;

namespace Unicamente.UI.Web.Models
{
    public class ImobiliariaViewModel
    {
  
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage ="Formato de e-mail inválido")]
        public string Email { get; set; }

        [RegularExpression("^[a-zA-Z\\u00C0-\\u017F\\s]+$", ErrorMessage = "Digite um nome válido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NomeResponsavel { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Contato { get; set; }
    }

}
