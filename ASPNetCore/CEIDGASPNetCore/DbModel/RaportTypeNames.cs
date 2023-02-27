using System.ComponentModel.DataAnnotations;

namespace CEIDGASPNetCore.DbModel
{
    public class RaportTypeNames
    {
        [Key]
        public long Id { get; set; }
        public byte RaportType { get; set; }

        public string RaportTypeName { get; set; }
    }
}
