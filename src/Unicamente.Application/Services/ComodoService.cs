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
    public class ComodoService : IComodoService
    {
        private readonly IComodoRepository _comodoRepository;
        private readonly IMapper _mapper;

        public ComodoService(IComodoRepository comodoRepository, IMapper mapper)
        {
            _comodoRepository = comodoRepository;
            _mapper = mapper;
        }

        public int Add(ComodoDTO objeto)
        {
            var comodo = _mapper.Map<Comodo>(objeto);
           return _comodoRepository.Add(comodo);
        }

        public IEnumerable<ComodoDTO> GetAll()
        {
            var lista = _comodoRepository.GetAll();
            return _mapper.Map<IEnumerable<ComodoDTO>>(lista);
        }

        public ComodoDTO GetById(int? id)
        {
            var comodo = _comodoRepository.GetById(id);
            return _mapper.Map<ComodoDTO>(comodo);
        }

        public IEnumerable<ComodoDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _comodoRepository.Remove(id);
        }

        public void Update(ComodoDTO objeto)
        {
            var comodo = _mapper.Map<Comodo>(objeto);
            _comodoRepository.Update(comodo);
        }
    }
}
