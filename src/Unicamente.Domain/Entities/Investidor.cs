namespace Unicamente.Domain.Entities
{
    public class Investidor : BaseEntity
    {
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string HashConfirmarEmail { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public SituacaoCadastro SituacaoCadastro { get; set; }

        public ComplementoInvestidor Complemento { get; set; }

        public void ValidarDominio()
        {
            Complemento.ValidarDominio();            
        }


    }
}
