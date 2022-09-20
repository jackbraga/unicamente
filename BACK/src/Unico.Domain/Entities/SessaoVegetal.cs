namespace Unico.Domain.Entidades
{
    public class SessaoVegetal : BaseEntity
    {
        public int IdSessao { get; set; }
        public int IdVegetal { get; set; }
        public double Litros { get; set; }
    }
}