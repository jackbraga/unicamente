namespace Unico.Domain.Entidades
{
    public class MovimentoVegetal : BaseEntity
    {
        public int IdVegetal { get; set; }
        public int IdRecipiente { get; set; }
        public int IdTipoMovimento { get; set; }
        public DateTime DataMovimento { get; set; }
        public double Litros { get; set; }
        
        public bool EhRetorno { get; set; }
        public string Imagem { get; set; }
        public string Observacao { get; set; }
    }
}