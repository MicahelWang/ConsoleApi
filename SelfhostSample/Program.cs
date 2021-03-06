﻿using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using WebApiUtils;

namespace SelfhostSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server is is starting……");
            string baseAddress = "http://localhost:8080/";
            var config = new HttpSelfHostConfiguration(baseAddress);
            config.Filters.Add(new CrossSiteAttribute());
            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );
            int maxValue = 100 * 1024 * 1024;
            config.MaxBufferSize = maxValue;
                 config.MaxReceivedMessageSize = maxValue;
            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Server is started");
                Console.WriteLine("Server host is {0}.", baseAddress);
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
