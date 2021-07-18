using System;
using ConfigServices;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;
namespace ConsoleAppMailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IMailService,MailService>();
            services.AddSingleton<IMailService,MailService>();
            services.AddSingleton<ILogService, LogService>();
            services.AddSingleton<IConfigService, EnvVarConfigService>();
            //services.AddSingleton<IConfigService, EnvVarConfigService>();
            //services.AddSingleton(typeof(IConfigService),s=> new IniFileConfigService { FilePath = "mail.ini" });
            services.AddIniFileConfig("mail.ini");
            services.AddConsoleLog();
            services.AddConfigReader();
            using(ServiceProvider sp = services.BuildServiceProvider())
            {
                IMailService mail = sp.GetService<IMailService>();
                mail.Send("你好啊","123456789","0987654321");
            }
        }
    }
}
