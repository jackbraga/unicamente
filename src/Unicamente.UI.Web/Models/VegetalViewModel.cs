using System.ComponentModel.DataAnnotations;

namespace Unicamente.UI.Web.Models
{
    public class VegetalViewModel
    {
        public int ID { get; set; }

        [RegularExpression("^[a-zA-Z\\u00C0-\\u017F\\s]+$", ErrorMessage = "Digite um nome válido")]
        [MaxLength(50, ErrorMessage = "Permitido no máximo 50 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,1})?$", ErrorMessage = "Digite um valor válido")]
        [Range(0.1, 5.9, ErrorMessage = "O volume deve ter entre 0.1 e 5.9")]
        public string MestrePreparo { get; set; }
        public DateTime DataPreparo { get; set; }


        public int IDMariri { get; set; }
        public int IDChacrona { get; set; }

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
