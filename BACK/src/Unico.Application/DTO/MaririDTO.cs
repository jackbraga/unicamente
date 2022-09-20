using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Unico.Application.DTO
{
    public class MaririDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage= "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        public string Observacao { get; set; }
        public string? Imagem { get; set; }

        public IFormFile Arquivo { get; set; }

    }
}