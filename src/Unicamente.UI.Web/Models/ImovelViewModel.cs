namespace Unicamente.UI.Web.Models
{
    public class ImovelViewModel
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public TipoImovelViewModel TipoImovel { get; set; }

        public decimal Metragem { get; set; }
    }
}
