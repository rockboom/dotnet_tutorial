using System;
namespace ConfigServices
{
    public class EnvVarConfigService:IConfigService
    {
        public EnvVarConfigService()
        {
        }

        public string GetValue(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
    }
}
