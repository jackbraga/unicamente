using System.ComponentModel.DataAnnotations;

namespace Unicamente.UI.Web.Models
{
    public class TelaCadastroViewModel
    {
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        [MinLength(5, ErrorMessage = "O {0} deve ter no mínimo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A {0} é obrigatória")]
        public string Senha { get; set; }

        public string Celular { get; set; }
        public TipoPessoaViewModel TipoPessoa { get; set; }


        [EmailAddress(ErrorMessage = "A Confirmacao de e-mail está em formato inválido")]
        [Required(ErrorMessage = "A Confirmação de e-mail é obrigatório")]
        [Compare("Email", ErrorMessage = "Os e-mails não conferem")]
        public string ConfirmacaoEmail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A Confirmação da Senha é obrigatório")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmacaoSenha { get; set; }


    }
}
