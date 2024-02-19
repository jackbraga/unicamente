namespace Unicamente.Application.DTOs
{
    public class InvestidorDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }

        public string HashConfirmarEmail { get; set; }

        public TipoPessoaDTO TipoPessoa { get; set; }
        public SituacaoCadastroDTO SituacaoCadastro { get; set; }

        public ComplementoInvestidorDTO Complemento { get; set; }
    }
}
