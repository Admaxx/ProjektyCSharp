using AutoMapper;
using worldWideModels.ItemMapperModels;
using worldWideDbModels;

namespace worldWideModels.AutoMapperModels;

public class DTOProfiles : Profile
{
    public DTOProfiles()
    {
        CreateMap<CityDto, city_dto_AutoMapperModel>();
        CreateMap<City, city_AutoMapperModel>();
    }
}
