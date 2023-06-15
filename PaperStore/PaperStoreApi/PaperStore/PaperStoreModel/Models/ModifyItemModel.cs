using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperStoreModel.Models
{
    public class ModifyItemModel
    {
        public int? Qty { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string AdditionalDetail { get; set; }
    }
}
