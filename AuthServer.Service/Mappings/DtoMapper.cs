

using AuthServer.Model.Dtos;
using AuthServer.Model.Entity;
using AutoMapper;

namespace AuthServer.Service.Mappings;

public class DtoMapper : Profile
{
    public DtoMapper()
    {
        CreateMap<ProductDto,Product>().ReverseMap();
        CreateMap<UserAppDto,UserApp>().ReverseMap();
    }
}
