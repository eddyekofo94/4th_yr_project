using System;
using mlm.Services.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace mlm.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private IHubContext<Chat> _hubContext;

        public ChatController(IHubContext<Chat> hubContext)
        {
            _hubContext = hubContext;
        }

        // GET api/chat
//        [HttpGet]
//        public string Get()
//        {
//            _hubContext.Clients.All.InvokeAsync("Send", "sent!");
//            return "I have been called!";
//        }
//        public RealtimeController(IHubContext<Chat> chatHub)
//        {
//            this.chatHub = chatHub;
//        }

        [HttpPost, Route("[action]/{message}")]
        public void Send(string message)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Eror!!!!!!!!!!1");
            }

            _hubContext.Clients.All.InvokeAsync("Send", message);
        }
        [HttpGet, Route("[action]/{message}")]
        public void Get(string message)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Eror!!!!!!!!!!1");
            }

            _hubContext.Clients.All.InvokeAsync("Send", message);
        }
    }
}