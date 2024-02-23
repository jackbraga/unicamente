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
    public class MaririService : IMaririService
    {

        private readonly IMaririRepository _maririRepository;
        private readonly IMapper _mapper;

        public MaririService(IMaririRepository maririRepository, IMapper mapper)
        {
            _mapper = mapper;
            _maririRepository = maririRepository;
        }


        public int Add(MaririDTO objeto)
        {
            var mariri = _mapper.Map<Mariri>(objeto);
            return _maririRepository.Add(mariri);
        }

        public IEnumerable<MaririDTO> GetAll()
        {
            var mariris = _maririRepository.GetAll().OrderBy(x => x.Descricao);
            return _mapper.Map<IEnumerable<MaririDTO>>(mariris);
        }

        public MaririDTO GetById(int? id)
        {
            var mariri = _maririRepository.GetById(id);
            return _mapper.Map<MaririDTO>(mariri);
        }

        public IEnumerable<MaririDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _maririRepository.Remove(id);
        }

        public void Update(MaririDTO objeto)
        {
            var mariri = _mapper.Map<Mariri>(objeto);
            _maririRepository.Update(mariri);
        }
    }
}
