namespace Unicamente.Domain.Entities
{
    public class Chacrona:BaseEntity
    {
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public byte[] Imagem { get; set; }
    }
}
