using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using worldWideModels.ItemMapperModels;
using worldWideDbModels;

namespace worldWideModels.AutoMapperModels
{
    public class DTOProfiles : Profile
    {
        public DTOProfiles()
        {
            CreateMap<CityDto, city_dto_AutoMapperModel>();
            CreateMap<City, city_AutoMapperModel>();
        }
    }
}
