using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Microsoft.AspNet.SignalR;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(SignalRSelfHost.Startup))]
namespace SignalRSelfHost
{
    class Program
    {
        /*
         * Defining the primary path of execution.
         * In this method, a web application of type Startup is started at the specified URL (http://localhost:8080)
         */
        static void Main(string[] args)
        {
            /*
             * start signalr server on port 8080
             */
            string url = "http://localhost:8020";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable cors support
            app.UseCors(CorsOptions.AllowAll);

            // Create signalr resource
            app.MapSignalR();
        }
    }

    public class VesselHub: Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }

        public void Join(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }
    }
}
