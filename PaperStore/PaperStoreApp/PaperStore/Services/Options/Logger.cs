namespace PaperStore.Services.Options
{
    public class Logger : ILogging
    {
        public void WriteLog(string Message)
        {
            using (StreamWriter sw = new StreamWriter(AllData.logsFile, true))
            {
                sw.WriteLine($"{DateTime.Now},{Message}");
            }
        }
    }
}