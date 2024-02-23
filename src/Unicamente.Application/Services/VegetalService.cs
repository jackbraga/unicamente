using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicamente.Application.DTOs;
using Unicamente.Application.Interfaces;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;

namespace Unicamente.Application.Services
{
    public class VegetalService : IVegetalService
    {
        private readonly IVegetalRepository _vegetalRepository;
        private readonly IMapper _mapper;

        public VegetalService(IVegetalRepository vegetalRepository, IMapper mapper)
        {
            _mapper = mapper;
            _vegetalRepository = vegetalRepository;
        }


        public int Add(VegetalDTO objeto)
        {
            var vegetal = _mapper.Map<Vegetal>(objeto);
            return _vegetalRepository.Add(vegetal);
        }

        public IEnumerable<VegetalDTO> GetAll()
        {
            var vegetals = _vegetalRepository.GetAll().OrderBy(x => x.Descricao);
            return _mapper.Map<IEnumerable<VegetalDTO>>(vegetals);
        }

        public VegetalDTO GetById(int? id)
        {
            var vegetal = _vegetalRepository.GetById(id);
            return _mapper.Map<VegetalDTO>(vegetal);
        }

        public IEnumerable<VegetalDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _vegetalRepository.Remove(id);
        }

        public void Update(VegetalDTO objeto)
        {
            var vegetal = _mapper.Map<Vegetal>(objeto);
            _vegetalRepository.Update(vegetal);
        }
    }
}
