using System;
using Microsoft.Extensions.Options;

namespace Config_tutorial
{
    public class TestController
    {
        //private readonly Config optConfig;
        private readonly IOptionsSnapshot<Config> optConfig;
        public TestController(IOptionsSnapshot<Config> optConfig)
        {
            //this.optConfig = optConfig.Value;
            this.optConfig = optConfig;
        }
        public void Test()
        {
            Console.WriteLine(optConfig.Value.Age);
            Console.WriteLine("*****************");
            Console.WriteLine(optConfig.Value.Name);
            Console.WriteLine(optConfig.Value.Proxy.Address);
            Console.WriteLine(optConfig.Value.Proxy.Port);
            Console.WriteLine(string.Join(",",optConfig.Value.Proxy.Ids));
        }
    }
}
