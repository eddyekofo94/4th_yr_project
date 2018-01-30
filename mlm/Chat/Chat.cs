using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace mlm.Chat
{
    public class Chat : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.InvokeAsync("Send", message);
        }   
    }
}