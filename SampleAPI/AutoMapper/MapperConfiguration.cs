using AutoMapper;
using SampleAPI.DTO;
using SampleAPI.Model;

namespace SampleAPI.AutoMapper;

public class MapperConfiguration : Profile {

    public MapperConfiguration()
    {
        CreateMap<ClienteDTO, Cliente>()
            .ForMember(x => x.Nome,  opt => opt.MapFrom(x => x.Name))
            .ForMember(x => x.Sobrenome,  opt => opt.MapFrom(x => x.Name))
            .ForMember(x => x.Sobrenome,  opt => opt.MapFrom(x => x.Lastname));
    }
}