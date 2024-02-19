namespace Unicamente.Application.DTOs
{
    public class ComplementoInvestidorDTO
    {
        public int ID { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string OrgaoExpedidor { get; set; }
        public string UFRG { get; set; }
        public DateTime Nascimento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int IDInvestidor { get; set; }
    }
}
