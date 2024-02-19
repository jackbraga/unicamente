using Unicamente.Application.DTOs;
using Unicamente.Domain.Entities;

namespace Unicamente.Application.Interfaces
{
    public interface IInvestidorService : IBaseService<InvestidorDTO>
    {
        IEnumerable<TipoDocumentoDTO> GetAllTiposDocumento();

        bool VerificarSeExisteEmailInvestidor(string email);

        InvestidorDTO Login(LoginDTO login);

        void AtualizarDadosPessoais(InvestidorDTO investidor);

        void AtualizarEndereco(InvestidorDTO investidor);

        void ConfirmarEmail(string hash);

        void EnviaEmailContato(string nome, string email, string telefone, string assunto, string mensagem);
    }
}
