using System;
namespace Config_tutorial
{
    public class WebConfig
    {
        public ConnectStr Conn1 { get; set; }
        public ConnectStr ConnTest { get; set; }
        public Config Config { get; set; }
    } 
    public class ConnectStr
    {
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
    }
}
