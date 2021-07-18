using System;
using Microsoft.Extensions.Configuration;

namespace Config_tutorial
{
    // 主要是提供参数使用
    public class FxConfigSource:FileConfigurationSource
    {
        public FxConfigSource()
        {
        }

        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            EnsureDefaults(builder);
            return new FxConfigProvider(this);
        }
    }
}
