using AutoMapper;
using Unicamente.Application.DTOs;
using Unicamente.Domain.Entities;

namespace Unicamente.Application.Mappings
{
    public class DomainToDTOMappingProfile: Profile
    {
        public DomainToDTOMappingProfile()
        {


            CreateMap<Imobiliaria, ImobiliariaDTO>().ReverseMap();
            CreateMap<Recipiente, RecipienteDTO>().ReverseMap();
            CreateMap<Mariri, MaririDTO>().ReverseMap();
            CreateMap<Chacrona, ChacronaDTO>().ReverseMap();
            CreateMap<Vegetal, VegetalDTO>().ReverseMap();
        }
    }
}
