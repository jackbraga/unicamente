using AutoMapper;
using Unicamente.Application.DTOs;
using Unicamente.Application.Interfaces;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Application.Services
{
    public class ComodoImovelService : IComodoImovelService
    {
        private readonly IComodoImovelRepository _comodoImovelRepository;
        private readonly IMapper _mapper;
        public ComodoImovelService(IComodoImovelRepository comodoImovelRepository, IMapper mapper)
        {
            _comodoImovelRepository = comodoImovelRepository;
            _mapper = mapper;
        }
        public int Add(ComodoImovelDTO objeto)
        {
            var comodoImovel = _mapper.Map<ComodoImovel>(objeto);
            return _comodoImovelRepository.Add(comodoImovel);
        }

        public IEnumerable<ComodoImovelDTO> GetAll()
        {
            var listaComodoImovel = _comodoImovelRepository.GetAll();
            return _mapper.Map<IEnumerable<ComodoImovelDTO>>(listaComodoImovel);
        }

        public ComodoImovelDTO GetById(int? id)
        {
            var comodoImovel = _comodoImovelRepository.GetById(id);
            return _mapper.Map<ComodoImovelDTO>(comodoImovel);
        }

        public IEnumerable<ComodoImovelDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _comodoImovelRepository.Remove(id);
        }

        public void Update(ComodoImovelDTO objeto)
        {
            var comodoImovel = _mapper.Map<ComodoImovel>(objeto);
            _comodoImovelRepository.Update(comodoImovel);
        }
    }
}
