using System;
namespace LogServices
{
    public interface ILogService
    {
        void LogError(string msg);
        void LogInfo(string msg);
    }
}
