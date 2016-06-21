using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace SelfhostSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server is is starting……");
            string baseAddress = "http://localhost:8080/";
            var config = new HttpSelfHostConfiguration(baseAddress);

            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );
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
