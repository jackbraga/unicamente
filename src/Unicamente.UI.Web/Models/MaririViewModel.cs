using System.ComponentModel.DataAnnotations;

namespace Unicamente.UI.Web.Models
{
    public class MaririViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Selecione um Mariri da lista")]

        public int ID { get; set; }

        [RegularExpression("^[a-zA-Z\\u00C0-\\u017F\\s]+$", ErrorMessage = "Digite um nome válido")]
        [MaxLength(50, ErrorMessage = "Permitido no máximo 50 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }


        [MaxLength(100, ErrorMessage = "Permitido no máximo 100 caracteres")]
        public string Observacao { get; set; }
        public byte[] Imagem { get; set; }

        public string Imagem64()
        {
            if (this.Imagem != null)
            {

                return Convert.ToBase64String(Imagem);
            }
            return "";
        }
    }
}
