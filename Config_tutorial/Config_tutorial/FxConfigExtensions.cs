using System;
using Microsoft.Extensions.Configuration;

namespace Config_tutorial
{
    static class FxConfigExtensions
    {
        public static IConfigurationBuilder AddFxConfig(this IConfigurationBuilder cb,string path = null)
        {
            if(path == null)
            {
                path = "web.config";
            }
            cb.Add(new FxConfigSource() { Path = path });
            return cb;
        }
    }
}
