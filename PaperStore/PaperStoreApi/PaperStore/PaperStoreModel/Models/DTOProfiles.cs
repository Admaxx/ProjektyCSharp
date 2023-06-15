using AutoMapper;
namespace PaperStoreModel.Models
{
    public class DTOProfiles : Profile
    {
        public DTOProfiles()
        {
            CreateMap<CurrentStock, ModifyItemModel>()
                .ForMember(item => item.ProductName, items => items.MapFrom(item => item.ProductNameNavigation.ItemName))
                .ForMember(item => item.CompanyName, items => items.MapFrom(item => item.ProductNameNavigation.Company.CompanyName))
                .ForMember(item => item.AdditionalDetail, items => items.MapFrom(item => item.AddtionalInfoNavigation.AdditionalInfo));
        }

    }
}
