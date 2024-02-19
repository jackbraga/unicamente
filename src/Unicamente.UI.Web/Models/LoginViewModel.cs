using System.ComponentModel.DataAnnotations;

namespace Unicamente.UI.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o {0}")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "O {0} está em formato inválido")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(30)]
        [Required(ErrorMessage = "Informe a {0}")]
        public string Senha { get; set; }
    }
}
