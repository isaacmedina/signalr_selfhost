using Microsoft.AspNet.SignalR;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SignalRSelfHost
{
    public static class Notification
    {
        private static Timer _notificationTimer;
        private const int _ticInterval = 2000;
        private static IHubContext _hubContext;
        private static Random _random;
        private static string[] _Data;

        public static void StartNotificationPolling(this IAppBuilder app)
        {
            SetNotificationTimer();
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<VesselHub>();
            _notificationTimer.Start();
        }

        private static void SetData()
        {
            _Data = new string[5] { "", "", "", "", "" };
        }

        private static void SetNotificationTimer()
        {
            _notificationTimer = new Timer(_ticInterval);
            _notificationTimer.Elapsed += OnNotificationEvent;
            _notificationTimer.AutoReset = true;
            _notificationTimer.Enabled = true;
        }

        private static void OnNotificationEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("OnNotificationEvent Fired!");
            _hubContext.Clients.Group("FDMF").addMessage("Test message");
        }
    }
}
