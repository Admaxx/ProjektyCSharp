using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
