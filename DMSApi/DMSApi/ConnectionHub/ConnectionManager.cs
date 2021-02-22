using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMSApi.ConnectionHub
{
    public class ConnectionManager : Hub<SignalRCommunication>
    {
        public async Task PushMessage(string message, string connectionId)
        {
            await Clients.Client(connectionId).PushMessageAsync(message);
        }
    }

    public interface SignalRCommunication
    {
        Task PushMessageAsync(string message);
    }
}
