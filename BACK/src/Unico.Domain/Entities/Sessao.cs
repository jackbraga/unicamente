namespace Unico.Domain.Entidades
{
    public class Sessao
    {
        public int IdTipoSessao { get; set; }
        public string Dirigente { get; set; }

        public string QuemLeuDocumentos { get; set; }
        public string QuemFezExplanacao { get; set; }
        public string QuemFicouQuartoLugar { get; set; }

        public int QtdPessoas { get; set; }
        public DateTime DataSessao { get; set; }
    }
}