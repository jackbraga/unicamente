namespace Unicamente.Application.DTOs
{
    public class CorretorDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Contato1 { get; set; }
        public SituacaoCadastroDTO SituacaoCadastro { get; set; }
    }
}
