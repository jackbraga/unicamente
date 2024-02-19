namespace Unicamente.Domain.Entities
{
    public class Imobiliaria : BaseEntity
    {
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string NomeResponsavel { get; set; }
        public string Contato { get; set; }
    }
}
