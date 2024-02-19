using CorreiosService;

namespace Unicamente.Application.ExternalServices.Correios
{
    public class Correios: ICorreios
    {
        public Endereco ConsultaCEP(string cep)
        {
            AtendeClienteClient correios = new AtendeClienteClient();
            consultaCEPResponse resultado =  correios.consultaCEPAsync(cep).Result;

            Endereco endereco = new Endereco();
            endereco.Logradouro = resultado.@return.end;
            endereco.UF = resultado.@return.uf;
            endereco.Cidade = resultado.@return.cidade;
            endereco.Bairro = resultado.@return.bairro;

            return endereco;
        }
    }
}
