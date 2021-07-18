using System;
using Microsoft.Extensions.Options;

namespace Config_tutorial
{
    public class TestWebConfig
    {
        public IOptionsSnapshot<WebConfig> optWC;
        public TestWebConfig(IOptionsSnapshot<WebConfig> optWC)
        {
            this.optWC = optWC;
        }
        public void Test()
        {
            var wc = optWC.Value;
            Console.WriteLine(wc.Conn1.ConnectionString);
            Console.WriteLine(wc.Config.Age);
            Console.WriteLine(wc.Config.Proxy.Address);
    }
    }
    
}
