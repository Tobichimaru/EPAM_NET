using System;
using System.Web.Http.SelfHost;
using System.Web.Http;
using System.Net.Http;

namespace WebAPISelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MyConfig("http://localhost:8999");
            config.Routes.MapHttpRoute("default", 
                "api/{controller}/{id}", 
                new { id = RouteParameter.Optional}
            );
            var server = new HttpSelfHostServer(config);//, new MySimpleHttpMessageHandler());
            var task = server.OpenAsync();
            task.Wait();
            Console.WriteLine("Server is running!");
            //Console.WriteLine("Hit enter to start client:");
            Console.ReadLine();

            //var client = new HttpClient(server);
            //client.GetAsync("http://localhost:8999/api/my").ContinueWith((t) =>
            //    {
            //        var result = t.Result;
            //        result.Content.ReadAsStringAsync().ContinueWith((rt) =>
            //        {
            //            Console.WriteLine("Client got response" + rt.Result);
            //        });
            //    });
        }
    }
}
