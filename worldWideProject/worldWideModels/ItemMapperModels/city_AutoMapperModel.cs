using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worldWideModels.ItemMapperModels
{
    public class city_AutoMapperModel
    {
        public string Name { get; set; } = null!;
        public long Population { get; set; }
        public string Country { get; set; } = null!;
    }
}
