using AutoMapper;
namespace PaperStoreModel.Models
{
    public class DTOProfiles : Profile
    {
        public DTOProfiles()
        {
            CreateMap<CurrentStock, ModifyItemModel>();
        }

    }
}
