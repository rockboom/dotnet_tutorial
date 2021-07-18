using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Config_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            //configBuilder.AddJsonFile("config.json",optional:true,reloadOnChange: true);
            configBuilder.AddCommandLine(args);
            IConfigurationRoot configRoot = configBuilder.Build();
            services.AddOptions().Configure<Config>(e=>configRoot.Bind(e))
                                 .Configure<Proxy>(e=>configRoot.GetSection("proxy").Bind(e));
            services.AddScoped<TestController>();
            services.AddScoped<Test2>();

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddEnvironmentVariables();

            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                var controller = sp.GetService<TestController>();
                controller.Test();

                //while (true)
                //{
                //    using (var scope = sp.CreateScope())
                //    {
                //        var controller = scope.ServiceProvider.GetService<TestController>();
                //        controller.Test();

                //        var test2 = scope.ServiceProvider.GetService<Test2>();
                //        test2.Test();
                //    }
                //    Console.WriteLine("点击任意键继续.......");
                //    Console.ReadLine();
                //}

            }

            //string name = configRoot["name"];
            //Console.WriteLine($"name={name}");
            //string address = configRoot.GetSection("proxy:address").Value;
            //Console.WriteLine($"address={address}");

            //Proxy proxy = configRoot.GetSection("proxy").Get<Proxy>();
            //Console.WriteLine($"address={proxy.Address}");
            //Console.WriteLine($"port={proxy.Port}");

            //Config config = configRoot.Get<Config>();
            //Console.WriteLine($"{config.Name},{config.Age},{config.Proxy.Address},{config.Proxy.Port}");
        }
    }
    public class Config
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Proxy Proxy { get; set; }

    }
    public class Proxy
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public int[] Ids { get; set; }
    }
}
