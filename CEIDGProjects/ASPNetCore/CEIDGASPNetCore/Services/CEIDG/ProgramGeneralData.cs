namespace CEIDGREGON
{
    public class ProgramGeneralData
    {
        //Jest to token do testowego servera usługi GUS, dlatego jest podany w plainText
        public readonly string GusToken = "abcde12345abcde12345";

        internal Dictionary<string, byte> RaportTypes = new Dictionary<string, byte>()
        {
            {"DanePrzedmiotu",0},
            {"PelnyRaport",1},
            {"ZbiorczyRaport",2}
        };
        //Lista błędów, jakie można spotkać przy łączeniu się z bazą
        internal readonly Dictionary<int, string> SqlErrorsNumbers = new Dictionary<int, string>()
        {
            {40197,"Usługa napotkała błąd podczas przetwarzania Twojego żądania. Proszę spróbuj ponownie." },
            {40540,"Usługa napotkała błąd podczas przetwarzania Twojego żądania. Proszę spróbuj ponownie." },
            {233,"Niepoprawny login/hasło" },
            {18456,"Niepoprawny login/hasło" },
            {927,"Nie można otworzyć bazy danych. Jest w trakcie przywracania" },
            {87 ,"Wystąpił błąd związany z siecią lub instancją podczas nawiązywania połączenia z SQL Server. Serwer nie został znaleziony lub nie był dostępny. Sprawdź, czy nazwa instancji jest poprawna i czy program SQL Server jest skonfigurowany do zezwalania na połączenia zdalne"},
            {25 ,"Wystąpił błąd związany z siecią lub instancją podczas nawiązywania połączenia z SQL Server. Serwer nie został znaleziony lub nie był dostępny. Sprawdź, czy nazwa instancji jest poprawna i czy program SQL Server jest skonfigurowany do zezwalania na połączenia zdalne"}
        };
        internal readonly Dictionary<string, Dictionary<int, string>> KomunikatyBłędów = new Dictionary<string, Dictionary<int, string>>()
        {
            {"StatusSesji", new Dictionary<int, string>() { { 0, "Sesja nie istnieje" }, { 1, "Sesja istnieje" } } },

            {"StatusUslugi", new Dictionary<int, string>() { { 0, "Usługa niedostępna" }, { 1, "Usługa dostępna" }, { 2, "Przerwa techniczna" } } }

        };
    }
}
