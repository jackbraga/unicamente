using Unicamente.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Unicamente.Application.DTOs
{
    public class ImovelDTO
    {
        public int ID { get; set; }

        [DisplayName("Imovel")]
        public string Descricao { get; set; }
        public decimal Metragem { get; set; }
        public TipoImovel TipoImovel { get; set; }

    }
}
