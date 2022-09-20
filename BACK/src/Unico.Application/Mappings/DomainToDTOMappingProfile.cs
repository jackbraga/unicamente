using AutoMapper;
using Unico.Application.DTO;
using Unico.Domain.Entidades;

namespace Unico.Application.Mappings
{
    public class DomainToDTOMappingProfile: Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Mariri, MaririDTO>().ReverseMap();
            CreateMap<Chacrona, ChacronaDTO>().ReverseMap();
        }
        
    }
}
