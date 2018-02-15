using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System;
using mlm.Models.ChatViewModel;

namespace mlm.Services.Hubs
{
    public class Chat : Hub<Chat.IBroadcaster>
    {
        public override Task OnConnectedAsync()
        {
            Groups.AddAsync(Context.ConnectionId, "groupName");

            return base.OnConnectedAsync();
//            return Clients.Client(Context.ConnectionId).SetConnectionId(Context.ConnectionId);
//                InvokeAsync("UserConnected", Context.User.Identity.Name);
        }
        

        public Task Subscribe(string chatroom)
        {
            return Groups.AddAsync(Context.ConnectionId, chatroom);
        }

        public Task UnSubscribe(string chatroom)
        {
            return Groups.RemoveAsync(Context.ConnectionId, chatroom);
        }

        public interface IBroadcaster
        {
            Task SetConnectionId(string connectionId);
            Task AddChatMessage(MessageViewModel message);
        }
//        private UserInfoInMemory _userInfoInMemory;

//        public async Task Send(string message)
//        {
//            await Clients.All.InvokeAsync("Send", message);
//        }   
    }
}