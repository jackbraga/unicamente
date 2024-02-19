using AutoMapper;
using Unicamente.Application.DTOs;
using Unicamente.Application.Interfaces;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;

namespace Unicamente.Application.Services
{
    public class EmpreendimentoService : IEmpreendimentoService
    {
        private readonly IEmpreendimentoRepository _empreendimentoRepository;
        private readonly IMapper _mapper;

        public EmpreendimentoService(IEmpreendimentoRepository empreendimentoRepository, IMapper mapper)
        {
            _empreendimentoRepository = empreendimentoRepository;
            _mapper = mapper;
        }
        public int Add(EmpreendimentoDTO objeto)
        {
            var empreendimento = _mapper.Map<Empreendimento>(objeto);
           return _empreendimentoRepository.Add(empreendimento);
        }

        public IEnumerable<EmpreendimentoDTO> GetAll()
        {
            var lista = _empreendimentoRepository.GetAll();
            return _mapper.Map<IEnumerable<EmpreendimentoDTO>>(lista);
        }

        public EmpreendimentoDTO GetById(int? id)
        {
            var empreendimento = _empreendimentoRepository.GetById(id);
            return _mapper.Map<EmpreendimentoDTO>(empreendimento);
        }

        public IEnumerable<EmpreendimentoDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _empreendimentoRepository.Remove(id);
        }

        public void Update(EmpreendimentoDTO objeto)
        {
            var empreendimento = _mapper.Map<Empreendimento>(objeto);
            _empreendimentoRepository.Update(empreendimento);
        }
    }
}
