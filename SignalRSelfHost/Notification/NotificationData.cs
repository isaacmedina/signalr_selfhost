using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRSelfHost
{
    public class NotificationData
    {
        public List<NotificationItem> Data;
        public List<string> groups = new List<string>()
        {
            "FDMF",
            "FDPM",
            "FDGT",
            "FDCO",
            "FDAC"
        };

        public int Count { get; set; }
        public NotificationData()
        {
            Data = new List<NotificationItem>();
            LoadInitialData();
        }

        public NotificationItem GetNotificationItem(int key)
        {
            return Data.FirstOrDefault(x => x.key == key);
        }

        private void LoadInitialData()
        {
            int key = 1;
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Notification\Data"));
            DirectoryInfo directory = new DirectoryInfo(path);
            foreach (string group in groups)
            {
                FileInfo[] Files = directory.GetFiles($"{group}*.json");
                foreach (FileInfo file in Files)
                {
                    Data.Add(new NotificationItem()
                    {
                        key = key,
                        group = group,
                        message = file.OpenText().ReadToEnd()
                    });
                    key++;
                }
            }
            Count = key;
        }
    }

    public interface INotificationData
    {
        List<NotificationItem> Data { get; set; }
        int Count { get; set; }
        NotificationItem GetNotificationItem(int key);
    }

    public class NotificationItem
    {
        public int key { get; set; }
        public string group { get; set; }
        public string message { get; set; }
    }
}
