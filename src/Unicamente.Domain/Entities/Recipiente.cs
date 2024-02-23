namespace Unicamente.Domain.Entities
{
    public class Recipiente : BaseEntity
    {
        public string Descricao { get; set; }
        public double Volume { get; set; }
        public int QuantidadeReuso { get; set; }
        public string Observacao { get; set; }
        public byte[] Imagem { get; set; }
    }
}
