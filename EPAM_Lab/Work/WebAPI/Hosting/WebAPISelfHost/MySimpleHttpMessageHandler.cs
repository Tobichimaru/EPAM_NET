using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace WebAPISelfHost
{ 
    public class MySimpleHttpMessageHandler : HttpMessageHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> 
            SendAsync(HttpRequestMessage request, 
                System.Threading.CancellationToken cancellationToken)
        {
            Console.WriteLine("Received message!");
            var task = new Task<HttpResponseMessage>(() =>
            {
                var msg = new HttpResponseMessage();
                var un = Thread.CurrentPrincipal.Identity.Name;
                msg.Content = new StringContent("Hello self-hosting" + un);
                Console.WriteLine("http response send");
                return msg;
            });
            task.Start();
            return task;
        }
    }
}
