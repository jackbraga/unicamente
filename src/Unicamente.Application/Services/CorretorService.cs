using AutoMapper;
using Unicamente.Application.DTOs;
using Unicamente.Application.Interfaces;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;

namespace Unicamente.Application.Services
{
    public class CorretorService : ICorretorService
    {
        private readonly ICorretorRepository _corretorRepository;
        private readonly IMapper _mapper;

        public CorretorService(ICorretorRepository corretorRepository, IMapper mapper)
        {
            _corretorRepository = corretorRepository;
            _mapper = mapper;
        }
        public int Add(CorretorDTO objeto)
        {
            var corretor = _mapper.Map<Corretor>(objeto);
            return _corretorRepository.Add(corretor);
        }

        public IEnumerable<CorretorDTO> GetAll()
        {
            var listaCorretor = _corretorRepository.GetAll();
            return _mapper.Map<IEnumerable<CorretorDTO>>(listaCorretor);
        }

        public CorretorDTO GetById(int? id)
        {
            var corretor = _corretorRepository.GetById(id);
            return _mapper.Map<CorretorDTO>(corretor);
        }

        public IEnumerable<CorretorDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _corretorRepository.Remove(id);
        }

        public void Update(CorretorDTO objeto)
        {
            var corretor = _mapper.Map<Corretor>(objeto);
            _corretorRepository.Update(corretor);
        }
    }
}
