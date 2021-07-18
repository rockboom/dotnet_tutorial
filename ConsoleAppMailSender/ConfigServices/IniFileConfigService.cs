using System;
using System.IO;
using System.Text;
using System.Linq;

namespace ConfigServices
{
    public class IniFileConfigService:IConfigService
    {
        public string FilePath { get; set; }
        public IniFileConfigService()
        {
        }

        public string GetValue(string name)
        {
            var kv = File.ReadAllLines(FilePath).Select(s => s.Split("=")).Select(str => new { Name = str[0], Value = str[1] })
                .SingleOrDefault(kv => kv.Name == name);
            if (kv != null)
            {
                return kv.Value;
            }
            else
            {
                return null;
            }
        }
    }
}
