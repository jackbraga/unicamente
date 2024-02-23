using AutoMapper;
using CorreiosService;
using Unicamente.Application.DTOs;
using Unicamente.Application.Interfaces;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;

namespace Unicamente.Application.Services
{
    public class RecipienteService : IRecipienteService
    {

        private readonly IRecipienteRepository _recipienteRepository;
        private readonly IMapper _mapper;

        public RecipienteService(IRecipienteRepository recipienteRepository, IMapper mapper)
        {
            _recipienteRepository = recipienteRepository;
            _mapper = mapper;
        }


        public int Add(RecipienteDTO objeto)
        {
            var recipiente = _mapper.Map<Recipiente>(objeto);
            return _recipienteRepository.Add(recipiente);
        }

        public IEnumerable<RecipienteDTO> GetAll()
        {
            var recipientes = _recipienteRepository.GetAll().OrderBy(x => x.Descricao);
            return _mapper.Map<IEnumerable<RecipienteDTO>>(recipientes);
        }

        public RecipienteDTO GetById(int? id)
        {
            var recipiente = _recipienteRepository.GetById(id);
            return _mapper.Map<RecipienteDTO>(recipiente);
        }

        public IEnumerable<RecipienteDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _recipienteRepository.Remove(id);
        }

        public void Update(RecipienteDTO objeto)
        {
            var recipiente = _mapper.Map<Recipiente>(objeto);
            _recipienteRepository.Update(recipiente);
        }
    }
}
