namespace Unicamente.Domain.Entities
{
    public class Empreendimento : BaseEntity
    {
        public string Descricao { get; set; }
        public string Matricula { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }   
}
