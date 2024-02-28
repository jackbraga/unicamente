using System.ComponentModel.DataAnnotations;

namespace Unicamente.UI.Web.Models
{
    public class VegetalViewModel
    {
        public int ID { get; set; }

        [MaxLength(50, ErrorMessage = "Permitido no máximo 50 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string MestrePreparo { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataPreparo { get; set; }

        public MaririViewModel Mariri { get; set; }
        public ChacronaViewModel Chacrona { get; set; }

        //public int IDMariri { get; set; }
        //public int IDChacrona { get; set; }

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
