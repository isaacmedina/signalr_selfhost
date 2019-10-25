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
        private List<NotificationItem> _Data;
        private List<string> groups = new List<string>()
        {
            "FDMF",
            "FDPM",
            "FDGT",
            "FDCO",
            "FDAC"
        };
        private int _Count;

        public int Count { get; set; }
        public NotificationData()
        {
            LoadInitialData();
        }

        public NotificationItem GetNotificationItem(int key)
        {
            return _Data.FirstOrDefault(x => x.key == key);
        }

        private void LoadInitialData()
        {
            int key = 1;
            DirectoryInfo directory = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}");
            foreach (string group in groups)
            {
                FileInfo[] Files = directory.GetFiles($"{group}*.json");
                foreach (FileInfo file in Files)
                {
                    _Data.Add(new NotificationItem()
                    {
                        key = key,
                        group = group,
                        message = file.OpenText().ReadToEnd()
                    });
                    key++;
                }
            }
        }
    }

    public class NotificationItem
    {
        public int key { get; set; }
        public string group { get; set; }
        public string message { get; set; }
    }
}
