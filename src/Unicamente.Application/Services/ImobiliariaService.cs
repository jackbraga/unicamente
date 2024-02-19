using AutoMapper;
using Unicamente.Application.DTOs;
using Unicamente.Application.Interfaces;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;

namespace Unicamente.Application.Services
{
    public class ImobiliariaService : IImobiliariaService
    {
        private readonly IImobiliariaRepository _imobiliariaRepository;
        private readonly IMapper _mapper;

        public ImobiliariaService(IImobiliariaRepository imobiliariaRepository, IMapper mapper)
        {
            _imobiliariaRepository = imobiliariaRepository;
            _mapper = mapper;
        }

        public int Add(ImobiliariaDTO objeto)
        {
            var imobiliaria = _mapper.Map<Imobiliaria>(objeto);
            if (VerificarSeExisteEmailImobiliaria(objeto.Email.Trim()))
            {
                throw new Exception("E-mail já cadastrado! Efetue o cadastro com outro endereço");
            }
            return _imobiliariaRepository.Add(imobiliaria);
        }

        public IEnumerable<ImobiliariaDTO> GetAll()
        {
            var imobiliarias = _imobiliariaRepository.GetAll().OrderBy(x=>x.RazaoSocial);
            return _mapper.Map<IEnumerable<ImobiliariaDTO>>(imobiliarias);
        }

        public ImobiliariaDTO GetById(int? id)
        {
            var imob = _imobiliariaRepository.GetById(id);
            return _mapper.Map<ImobiliariaDTO>(imob);
        }

        public IEnumerable<ImobiliariaDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ImobiliariaDTO objeto)
        {
            var imobiliaria = _mapper.Map<Imobiliaria>(objeto);
             _imobiliariaRepository.Update(imobiliaria);
        }


        private bool VerificarSeExisteEmailImobiliaria(string email)
        {
            var imob = _imobiliariaRepository.GetByEmail(email);
            return imob != null;
        }
    }
}
