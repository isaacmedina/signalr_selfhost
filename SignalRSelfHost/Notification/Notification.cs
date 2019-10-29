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
        private const int _ticInterval = 500;
        private static IHubContext _hubContext;
        private static Random _random;
        private static NotificationData _Data;

        public static void StartNotificationPolling(this IAppBuilder app)
        {
            SetNotificationData();
            InitializeNotificationTimer();
            SetHubContext();
            StartNotification();
        }

        private static void StartNotification()
        {
            _notificationTimer.Start();
        }

        private static void SetHubContext()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<VesselHub>();
        }

        private static void SetNotificationData()
        {
            _random = new Random();
            _Data = new NotificationData();
        }

        private static void InitializeNotificationTimer()
        {
            _notificationTimer = new Timer(_ticInterval);
            _notificationTimer.Elapsed += OnNotificationEvent;
            _notificationTimer.AutoReset = true;
            _notificationTimer.Enabled = true;
        }

        private static void OnNotificationEvent(Object source, ElapsedEventArgs e)
        {
            int key = _random.Next(1, _Data.Count);
            NotificationItem item = _Data.GetNotificationItem(key);
            Console.WriteLine($"OnNotificationEvent fired for group {item.group} at time: {DateTime.Now.ToLongTimeString()}");
            _hubContext.Clients.Group(item.group).addMessage(item.message);
        }
    }
}
