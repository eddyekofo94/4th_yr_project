using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System;

namespace mlm.Services.Hubs
{
    public class Chat : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.InvokeAsync("Send", message);
        }   
    }
}