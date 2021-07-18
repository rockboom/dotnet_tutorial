using System;
using Microsoft.Extensions.Options;

namespace Config_tutorial
{
    public class Test2
    {
        //private readonly Config optConfig;
        private readonly IOptionsSnapshot<Proxy> optProxy;
        
        public void Test()
        {
            Console.WriteLine(optProxy.Value.Address);
            Console.WriteLine("*****************");
            Console.WriteLine(optProxy.Value.Port);
        }
        public Test2(IOptionsSnapshot<Proxy> optProxy)
        {
            this.optProxy = optProxy;
        }
    }
}
