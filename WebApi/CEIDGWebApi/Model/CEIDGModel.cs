using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEIDGWebApi.Model
{
    [Table("GUSValues")]
    public class CEIDGModel
    {
        [Key]
        public int Id { get; set; }
        public string XMLValues { get; set; }
        public DateTime ImportDate { get; set; }
        public byte RaportType { get; set; }
    }
}
