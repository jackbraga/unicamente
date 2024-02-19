using AutoMapper;
using Unicamente.Application.DTOs;
using Unicamente.UI.Web.Models;

namespace Unicamente.UI.Web.Mappings
{
    public class ViewModelToDTOMappingProfile:Profile
    {
        public ViewModelToDTOMappingProfile()
        {
            CreateMap<ImovelDTO,ImovelViewModel>().ReverseMap();
            CreateMap<InvestidorDTO, TelaCadastroViewModel>().ReverseMap();
            CreateMap<InvestidorDTO, InvestidorViewModel>().ReverseMap();
            CreateMap<TipoPessoaDTO, TipoPessoaViewModel>().ReverseMap();
            CreateMap<LoginDTO, LoginViewModel>().ReverseMap();
            CreateMap<ComplementoInvestidorDTO, ComplementoInvestidorViewModel>().ReverseMap();
            CreateMap<ImobiliariaDTO, ImobiliariaViewModel>().ReverseMap();
        }
    }
}
