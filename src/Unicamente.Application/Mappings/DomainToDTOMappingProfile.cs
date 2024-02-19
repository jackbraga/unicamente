using AutoMapper;
using Unicamente.Application.DTOs;
using Unicamente.Domain.Entities;

namespace Unicamente.Application.Mappings
{
    public class DomainToDTOMappingProfile: Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Imovel,ImovelDTO>().ReverseMap();
            CreateMap<TipoImovel,TipoImovelDTO>().ReverseMap();
            CreateMap<Comodo,ComodoDTO>().ReverseMap();
            CreateMap<ComodoImovel,ComodoImovelDTO>().ReverseMap();
            CreateMap<Investidor,InvestidorDTO>().ReverseMap();
            CreateMap<TipoDocumento,TipoDocumentoDTO>().ReverseMap();
            CreateMap<Corretor,CorretorDTO>().ReverseMap();
            CreateMap<Empreendimento,EmpreendimentoDTO>().ReverseMap();
            CreateMap<SituacaoCadastro,SituacaoCadastroDTO>().ReverseMap();
            CreateMap<TipoPessoa,TipoPessoaDTO>().ReverseMap();
            CreateMap<ComplementoInvestidor, ComplementoInvestidorDTO>().ReverseMap();
            CreateMap<Imobiliaria, ImobiliariaDTO>().ReverseMap();
        }
    }
}
