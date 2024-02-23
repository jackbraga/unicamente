using Microsoft.AspNetCore.Server.IIS.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unicamente.UI.Web.Models
{
    public class RecipienteViewModel
    {
        public int ID { get; set; }

        [RegularExpression("^[a-zA-Z\\u00C0-\\u017F\\s]+$", ErrorMessage = "Digite um nome válido")]
        [MaxLength(50, ErrorMessage = "Permitido no máximo 50 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,1})?$", ErrorMessage = "Digite um valor válido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0.1, 5.9, ErrorMessage = "O volume deve ter entre 0.1 e 5.9")]
        public double Volume { get; set; }

        [DefaultValue(1)]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, 5, ErrorMessage = "O volume deve ter entre 1 e 5")]

        public int QuantidadeReuso { get; set; }

        [MaxLength(100, ErrorMessage = "Permitido no máximo 100 caracteres")]

        public string Observacao { get; set; }
        public byte[] Imagem { get; set; }

        public string Imagem64()
        {
            if (this.Imagem != null)
            {

                return "data:image/png;base64," + Convert.ToBase64String(Imagem);
            }
            return "";
        }
    }
}
