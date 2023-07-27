using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worldWideModels.ItemMapperModels
{
    public class city_dto_AutoMapperModel
    {
        public string Name { get; set; } = null!;
        public long? Population { get; set; }

        public string Country { get; set; } = null!;

        public string Region { get; set; } = null!;

    }
}
