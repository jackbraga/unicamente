using AutoMapper;
using LanchoneteUDV.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Application.DTO;
using Unico.Application.Interfaces;
using Unico.Domain.Entidades;
using Unico.Domain.Interfaces;

namespace Unico.Application.Services
{
    public class ChacronaService : IChacronaService
    {
        private readonly IChacronaRepository _repository;
        private readonly IMapper _mapper;
        public ChacronaService(IChacronaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Add(ChacronaDTO objeto)
        {
            
            objeto.Imagem = SaveImage(objeto.Arquivo);
            var chacrona = _mapper.Map<Chacrona>(objeto);

            _repository.Add(chacrona);
        }

        public IEnumerable<ChacronaDTO> GetAll()
        {
            var lista =  _repository.GetAll();
            return _mapper.Map<IEnumerable<ChacronaDTO>>(lista);
        }

        public async Task<IEnumerable<ChacronaDTO>> GetAllAsync()
        {
            var lista =  _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ChacronaDTO>>(lista);
        }

        public ChacronaDTO GetById(int? id)
        {
            var chacrona = _repository.GetById(id);
            return _mapper.Map<ChacronaDTO>(chacrona);
        }

        public IEnumerable<ChacronaDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var chacrona = GetById(id);
            if (chacrona.Imagem!=null)
            {
                DeleteImage(chacrona.Imagem);
            }
            
            _repository.Remove(id);
            
        }

        public void Update(ChacronaDTO objeto)
        {
            var chacrona = _repository.GetById(objeto.Id);
            DeleteImage(chacrona.Imagem);
            chacrona.Imagem = SaveImage(objeto.Arquivo);

            _repository.Update(chacrona);
        }

        public string SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName)
                                              .Take(10)
                                              .ToArray()
                                         ).Replace(' ', '-');

            imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imageFile.FileName)}";

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources/images", imageName); ;

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            return imageName;
        }

        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources/images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }


    }
}
