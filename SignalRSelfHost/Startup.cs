using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(SignalRSelfHost.Startup))]
namespace SignalRSelfHost
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable cors support
            app.UseCors(CorsOptions.AllowAll);

            // Create signalr resource
            app.MapSignalR();

            // Start notifications
            app.StartNotificationPolling();
        }
    }
}
