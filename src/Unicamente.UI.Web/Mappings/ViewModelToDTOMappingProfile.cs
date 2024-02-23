using AutoMapper;
using Unicamente.Application.DTOs;
using Unicamente.UI.Web.Models;

namespace Unicamente.UI.Web.Mappings
{
    public class ViewModelToDTOMappingProfile:Profile
    {
        public ViewModelToDTOMappingProfile()
        {
            CreateMap<ImobiliariaDTO, ImobiliariaViewModel>().ReverseMap();
            CreateMap<RecipienteDTO, RecipienteViewModel>().ReverseMap();
            CreateMap<MaririDTO, MaririViewModel>().ReverseMap();
            CreateMap<ChacronaDTO, ChacronaViewModel>().ReverseMap();
            CreateMap<VegetalDTO, VegetalViewModel>().ReverseMap();
        }
    }
}
