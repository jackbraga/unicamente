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
    public class MaririService : IMaririService
    {
        private readonly IMaririRepository _repository;
        private readonly IMapper _mapper;
        public MaririService(IMaririRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Add(MaririDTO objeto)
        {
            
            objeto.Imagem = SaveImage(objeto.Arquivo);
            var mariri = _mapper.Map<Mariri>(objeto);

            _repository.Add(mariri);
        }

        public IEnumerable<MaririDTO> GetAll()
        {
            var lista =  _repository.GetAll();
            return _mapper.Map<IEnumerable<MaririDTO>>(lista);
        }

        public async Task<IEnumerable<MaririDTO>> GetAllAsync()
        {
            var lista =  _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaririDTO>>(lista);
        }

        public MaririDTO GetById(int? id)
        {
            var mariri = _repository.GetById(id);
            return _mapper.Map<MaririDTO>(mariri);
        }

        public IEnumerable<MaririDTO> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var mariri = GetById(id);
            if (mariri.Imagem!=null)
            {
                DeleteImage(mariri.Imagem);
            }
            
            _repository.Remove(id);
            
        }

        public void Update(MaririDTO objeto)
        {
            var mariri = _repository.GetById(objeto.Id);
            DeleteImage(mariri.Imagem);
            mariri.Imagem = SaveImage(objeto.Arquivo);

            _repository.Update(mariri);
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
