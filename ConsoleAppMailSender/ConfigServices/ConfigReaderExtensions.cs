using System;
using ConfigServices;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigReaderExtensions
    {
        public static void AddConfigReader(this IServiceCollection services)
        {
            services.AddSingleton<IConfigReader, ConfigReader>();
        }
    }
}
