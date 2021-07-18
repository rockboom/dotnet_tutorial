using System;
namespace LogServices
{
    public class LogService: ILogService
    {
        public LogService()
        {
        }

        public void LogError(string msg)
        {
            Console.WriteLine($"ERROR: {msg}");
        }

        public void LogInfo(string msg)
        {
            Console.WriteLine($"INFO: {msg}");
        }
    }
}
