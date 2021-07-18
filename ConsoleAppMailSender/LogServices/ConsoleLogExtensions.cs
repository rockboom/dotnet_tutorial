using System;
using LogServices;
using Microsoft.Extensions.DependencyInjection;
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConsoleLogExtensions
    {
        public static void AddConsoleLog(this IServiceCollection services)
        {
            services.AddScoped<ILogService, LogService>();
        }
    }
}
