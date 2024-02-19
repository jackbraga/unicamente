using System.ComponentModel.DataAnnotations;

namespace Unicamente.Application.DTOs
{
    public class TipoDocumentoDTO
    {
        [Display(Name = "Tipo de Documento")]
        public int ID { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }

        public string DescricaoCompleta
        {
            get
            {
                return $"{Sigla} - {Descricao}";
            }

        }
    }
}
