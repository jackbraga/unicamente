using Unicamente.Domain.Entities;

namespace Unicamente.Domain.Interfaces
{
    public interface IInvestidorRepository : IBaseRepository<Investidor>
    {
        IEnumerable<TipoDocumento> GetAllTiposDocumento();

        public Investidor GetByEmail(string email);

        public void AtualizarDadosPessoais(Investidor investidor);

        public void AtualizarEndereco(Investidor investidor);

        public void AtualizarSenha(Investidor investidor);

        void ConfirmarEmail(string has);
    }
}
