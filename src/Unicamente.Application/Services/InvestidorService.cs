using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Unicamente.Application.DTOs;
using Unicamente.Application.ExternalServices.Email;
using Unicamente.Application.Interfaces;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;
using Unicamente.Domain.Uteis;
using System.Security.Cryptography;

namespace Unicamente.Application.Services
{
    public class InvestidorService : IInvestidorService
    {

        private readonly IInvestidorRepository _investidorRepository;
        private readonly IMapper _mapper;

        public InvestidorService(IInvestidorRepository investidorRepository, IMapper mapper)
        {
            _investidorRepository = investidorRepository;
            _mapper = mapper;
        }

        public int Add(InvestidorDTO objeto)
        {
            var investidor = _mapper.Map<Investidor>(objeto);

            if (VerificarSeExisteEmailInvestidor(investidor.Email.Trim()))
            {
                throw new Exception("E-mail já cadastrado! Efetue o cadastro com outro endereço");
            }

            investidor.Senha = CriptografarHash.GerarHashCriptografado(objeto.Senha);
            investidor.HashConfirmarEmail = CriptografarHash.GerarHashCriptografado(string.Concat(investidor.ID.ToString(), DateTime.Now.ToString()));

            int idInserido = _investidorRepository.Add(investidor);
            Email.EmailAtivacaoConta(investidor.Nome, investidor.Email, investidor.HashConfirmarEmail);

            return idInserido;
        }

        public void AtualizarDadosPessoais(InvestidorDTO investidordto)
        {
            var investidor = _mapper.Map<Investidor>(investidordto);

            investidor.ValidarDominio();


            _investidorRepository.AtualizarDadosPessoais(investidor);
        }

        public void AtualizarEndereco(InvestidorDTO investidor)
        {
            var investidordto = _mapper.Map<Investidor>(investidor);
            _investidorRepository.AtualizarEndereco(investidordto);
        }

        public void ConfirmarEmail(string hash)
        {
            _investidorRepository.ConfirmarEmail(hash);
        }

        public IEnumerable<InvestidorDTO> GetAll()
        {
            var listaInvestidor = _investidorRepository.GetAll();
            return _mapper.Map<IEnumerable<InvestidorDTO>>(listaInvestidor);
        }

        public IEnumerable<TipoDocumentoDTO> GetAllTiposDocumento()
        {
            var listaTipoDocumento = _investidorRepository.GetAllTiposDocumento();
            return _mapper.Map<IEnumerable<TipoDocumentoDTO>>(listaTipoDocumento);
        }

        public InvestidorDTO GetById(int? id)
        {
            var investidor = _investidorRepository.GetById(id);
            return _mapper.Map<InvestidorDTO>(investidor);
        }

        public IEnumerable<InvestidorDTO> GetByName(string texto)
        {
            throw new NotImplementedException();

        }

        public InvestidorDTO Login(LoginDTO login)
        {
            var investidor = _investidorRepository.GetByEmail(login.Email);

            if (investidor == null)
                throw new Exception("Email ou senha incorretos");


            var senhaInformada = CriptografarHash.GerarHashCriptografado(login.Senha);

            if (senhaInformada == investidor.Senha)
            {
                return _mapper.Map<InvestidorDTO>(investidor);
            }
            else
            {
                throw new Exception("Email ou senha incorretos");
            }
        }

        public void Remove(int id)
        {
            _investidorRepository.Remove(id);
        }

        public void Update(InvestidorDTO objeto)
        {
            var investidor = _mapper.Map<Investidor>(objeto);
            _investidorRepository.Update(investidor);
        }

        public bool VerificarSeExisteEmailInvestidor(string email)
        {
            var investidor = _investidorRepository.GetByEmail(email);
            return investidor != null;
        }

        public void EnviaEmailContato(string nome, string email, string telefone, string assunto, string mensagem)
        {
            Email.EmailContato(nome, email, telefone, assunto, mensagem);

        }
    }
}
