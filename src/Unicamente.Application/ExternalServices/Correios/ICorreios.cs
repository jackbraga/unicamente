using CorreiosService;

namespace Unicamente.Application.ExternalServices.Correios
{
    public interface ICorreios
    {
        Endereco ConsultaCEP(string cep);
    }
}
