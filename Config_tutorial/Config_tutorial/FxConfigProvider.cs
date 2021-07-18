using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.Extensions.Configuration;

namespace Config_tutorial
{
    public class FxConfigProvider : FileConfigurationProvider
    {
        public FxConfigProvider(FxConfigSource src) : base(src)
        {

        }
        public override void Load(Stream stream)
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);
            var csNodes = xmlDoc.SelectNodes("/configuration/connectionStrings/add");
            foreach(XmlNode xmlNode in csNodes.Cast<XmlNode>())
            {
                string name = xmlNode.Attributes["name"].Value;
                string connectionString = xmlNode.Attributes["connectionString"].Value;
                string attProvideName = xmlNode.Attributes["providerName"].Value;

                // [{conn1:{connectionString:"",providerName:"",name:""},conn2:{}]
                data[$"{name}:connectionString"] = connectionString;
                if (attProvideName != null)
                {
                    data[$"{name}:providerName"] = attProvideName;
                }
            }

            var asNodes = xmlDoc.SelectNodes("/configuration/appSettings/add");
            foreach (XmlNode xmlNode in asNodes.Cast<XmlNode>())
            {
                string key = xmlNode.Attributes["key"].Value;
                key = key.Replace(".",":");
                string value = xmlNode.Attributes["value"].Value;
                data[key] = value;
            }
            this.Data = data;
        }
    }
}
