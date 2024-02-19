using AutoMapper;
using Unicamente.Application.DTOs;
using Unicamente.Application.Interfaces;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;

namespace Unicamente.Application.Services
{
    public class ImovelService : IImovelService
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly IMapper _mapper;

        public ImovelService(IImovelRepository imovelRepository, IMapper mapper)
        {
            _imovelRepository = imovelRepository;
            _mapper = mapper;
        }

        public int Add(ImovelDTO objeto)
        {
            var imovel = _mapper.Map<Imovel>(objeto);
            return _imovelRepository.Add(imovel);
        }

        public IEnumerable<ImovelDTO> GetAll()
        {
            var imoveis = _imovelRepository.GetAll();
            return _mapper.Map<IEnumerable<ImovelDTO>>(imoveis);
        }

        public ImovelDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImovelDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {

        }

        public void Update(ImovelDTO objeto)
        {
            throw new NotImplementedException();
        }
    }
}
