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
            if (!ModelState.IsValid)
            {
                return;
            }
            _hubContext = hubContext;
        }

        // GET api/chat
        [HttpGet]
        public IActionResult Get(string message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid message") ;
            }
            _hubContext.Clients.All.InvokeAsync("Send", message);
            return Ok("I have been called!");
        }
   
    }
}