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
    public class ChacronaService:IChacronaService
    {
        private readonly IChacronaRepository _chacronaRepository;
        private readonly IMapper _mapper;

        public ChacronaService(IChacronaRepository chacronaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _chacronaRepository = chacronaRepository;
        }


        public int Add(ChacronaDTO objeto)
        {
            var chacrona = _mapper.Map<Chacrona>(objeto);
            return _chacronaRepository.Add(chacrona);
        }

        public IEnumerable<ChacronaDTO> GetAll()
        {
            var chacronas = _chacronaRepository.GetAll().OrderBy(x => x.Descricao);
            return _mapper.Map<IEnumerable<ChacronaDTO>>(chacronas);
        }

        public ChacronaDTO GetById(int? id)
        {
            var chacrona = _chacronaRepository.GetById(id);
            return _mapper.Map<ChacronaDTO>(chacrona);
        }

        public IEnumerable<ChacronaDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _chacronaRepository.Remove(id);
        }

        public void Update(ChacronaDTO objeto)
        {
            var chacrona = _mapper.Map<Chacrona>(objeto);
            _chacronaRepository.Update(chacrona);
        }
    }
}
