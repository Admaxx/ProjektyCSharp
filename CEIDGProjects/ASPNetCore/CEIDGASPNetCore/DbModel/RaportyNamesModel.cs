namespace CEIDGASPNetCore.DbModel
{
    public class RaportyNamesModel
    {
        public long Id { get; set; }
        public string NazwaRaportu { get; set; }
        public string Opis { get; set; }
        public string NazwaSkrocona { get; set; }
        public byte typRaportu { get; set; }
    }
}
