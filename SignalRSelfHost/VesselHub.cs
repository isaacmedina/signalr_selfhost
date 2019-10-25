using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRSelfHost
{
    public class VesselHub : Hub
    {
        public void Join(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }
    }
}
