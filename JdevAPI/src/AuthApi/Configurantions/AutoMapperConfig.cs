using AuthApi.Domain.Entities;
using AutoMapper;

namespace AuthApi.Configurantions
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<AdicionarUsuarioDTO, Usuario>()
                .ForMember(m => m.Nome, f => f.MapFrom(src => src.Nome))
                .ForMember(m => m.Senha, f => f.MapFrom(src => src.Senha))
                .ForMember(m => m.Email, f => f.MapFrom(src => src.Email));
        }
    }
}
