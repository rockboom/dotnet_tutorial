using System;
using System.Collections.Generic;

namespace ConfigServices
{
    public class ConfigReader:IConfigReader
    {
        private readonly IEnumerable<IConfigService> services;
        public ConfigReader(IEnumerable<IConfigService> services)
        {
            this.services = services;
        }

        public string GetValue(string name)
        {
            string value = null;
            foreach(var service in services)
            {
                string newValue = service.GetValue(name);
                if(newValue != null)
                {
                    value = newValue;
                }
            }
            return value;
        }
    }
}
