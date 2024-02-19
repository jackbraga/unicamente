using AutoMapper;
using Unicamente.Application.DTOs;
using Unicamente.Application.Interfaces;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;

namespace Unicamente.Application.Services
{
    public class TipoImovelService : ITipoImovelService
    {
        private readonly ITipoImovelRepository _tipoImovelRepository;
        private readonly IMapper _mapper;
        public TipoImovelService(ITipoImovelRepository tipoImovelRepository, IMapper mapper)
        {
            _tipoImovelRepository = tipoImovelRepository;
            _mapper = mapper;
        }
        public int Add(TipoImovelDTO objeto)
        {
            var tipoImovel = _mapper.Map<TipoImovel>(objeto);
            return _tipoImovelRepository.Add(tipoImovel);
        }

        public IEnumerable<TipoImovelDTO> GetAll()
        {
            var listaTipoImovel = _tipoImovelRepository.GetAll();
            return _mapper.Map<IEnumerable<TipoImovelDTO>>(listaTipoImovel);
        }

        public TipoImovelDTO GetById(int? id)
        {
            var tipoImovel = _tipoImovelRepository.GetById(id);

            return _mapper.Map<TipoImovelDTO>(tipoImovel);
        }

        public IEnumerable<TipoImovelDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _tipoImovelRepository.Remove(id);
        }

        public void Update(TipoImovelDTO objeto)
        {
            var tipoImovel = _mapper.Map<TipoImovel>(objeto);
            _tipoImovelRepository.Update(tipoImovel);
        }

     
    }
}
