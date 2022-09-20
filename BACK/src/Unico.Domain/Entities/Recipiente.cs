namespace Unico.Domain.Entidades
{
    public class Recipiente : BaseEntity
    {
        public string Descricao { get; set; }
        public double Volume { get; set; }
        public string Imagem { get; set; }
        public int QtdReuso { get; set; }
    }
}