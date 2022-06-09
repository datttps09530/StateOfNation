using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StateOfNation.Hubs
{
    public class AgentStatusHubs : Hub
    {
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<AgentStatusHubs>();
            context.Clients.All.displayAgentStatus();
        }
    }
}