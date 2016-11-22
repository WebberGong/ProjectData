using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ServiceStack.WebHost.Endpoints;
using ProjectData.Service;

[assembly: WebActivator.PreApplicationStartMethod(typeof(ProjectData.UI.AppHost), "Start")]
namespace ProjectData.UI
{
    public class AppHost : AppHostBase
    {
        private static Dictionary<string, string> serviceUrl = new Dictionary<string, string>();

        private AppHost()
            : base("ProjectData.Service", typeof(ProjectDataService).Assembly)
        {
        }

        public static Dictionary<string, string> ServiceUrl
        {
            get
            {
                return serviceUrl;
            }
        }

        public override void Configure(Funq.Container container)
        {
        }

        public static void Start()
        {
            FillServiceUrl();

            var host = new AppHost();
            host.Init();
        }

        private static void FillServiceUrl()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ServiceConfig.xml"));
            XmlNodeList serviceConfig = doc.GetElementsByTagName("ServiceConfig");
            foreach (XmlNode node in serviceConfig)
            {
                string key = "";
                string value = "";
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Name == "ServiceName")
                    {
                        key = childNode.InnerText;
                    }
                    if (childNode.Name == "Url")
                    {
                        value = childNode.InnerText;
                    }
                }
                if (!string.IsNullOrEmpty(key) && !serviceUrl.ContainsKey(key))
                {
                    serviceUrl.Add(key, value);
                }
            }
        }
    }
}
