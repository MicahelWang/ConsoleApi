using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace OwinSelfhostSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server is is starting……");
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            //using (WebApp.Start<Startup>(url: baseAddress))
            //{
            //    // Create HttpCient and make a request to api/values 
            //    HttpClient client = new HttpClient();

            //    var response = client.GetAsync(baseAddress + "api/values").Result;

            //    Console.WriteLine(response);
            //    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            //}

            //Console.ReadLine();
            WebApp.Start<Startup>(url: baseAddress);
            Console.WriteLine("Server is started");
            Console.WriteLine("Server host is {0}.", baseAddress);
            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }
    }
}
