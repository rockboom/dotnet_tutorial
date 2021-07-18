using System;
using ConfigServices;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IniFileConfigServiceExtensions
    {
        public static void AddIniFileConfig(this IServiceCollection services, string filePath)
        {
            services.AddScoped(typeof(IConfigService), s => new IniFileConfigService { FilePath = filePath });
        }
        
    }
}
