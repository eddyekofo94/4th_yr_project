using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mlm.Data;
using mlm.Models;
using mlm.Models.ChatModel.mlm;
using mlm.Models.ChatViewModel;
using mlm.Services.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace mlm.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        private readonly IHubContext<Chat> _hubContext;

        public ChatController(IHubContext<Chat> hubContext,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _context = ctx;
            _hubContext = hubContext;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpPost, Route("[action]/{message}")]
        public async Task<IActionResult> Send(string message)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Eror!!!");
                return BadRequest();
            }

            // Get the current user
            var user = await GetCurrentUserAsync();
            if (user == null) return Forbid();

            Console.WriteLine("USER ID: " + user.Id);
            // Create a new message to save to the database
            MessageModel newMessage = new MessageModel(message)
            {
                MessageText = message,
                UserId = user.Id,
                User = user
            };


            // Save the new message
            await _context.AddAsync(newMessage);
            Console.WriteLine(newMessage.MessageText, newMessage.MessageTranslated);
            await _context.SaveChangesAsync();

            MessageViewModel model = new MessageViewModel(newMessage);

//            Console.WriteLine("My User Name!!! " + user.Email, user.UserName, user.NormalizedEmail);
            //for a single group
//            await _hubContext.Clients.Group("MainChatRoom").InvokeAsync("Send", model);
//            await _hubContext.Clients.All.InvokeAsync("Send", model);
            //for a single group
            await _hubContext.Clients.Group("groupName").InvokeAsync("Send", model);
            //for a single client
//            await _hubContext.Clients.Client().InvokeAsync("Send", model);
//            return new NoContentResult();
            return Ok(model);
        }

        [HttpGet, Route("[action]")]
        public async Task<IActionResult> Get()
        {
            MessageModel[] messages = await _context.Message.Include(m => m.User).ToArrayAsync();
            List<MessageViewModel> model = new List<MessageViewModel>();
            foreach (MessageModel msg in messages)
            {
                Console.WriteLine(msg);
                model.Add(new MessageViewModel(msg));
            }

            return Json(model);
        }

        [HttpPost, Route("[action]/{message}")]
        public async Task<IActionResult> Post([FromBody] NewMessageViewModel message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Get the current user
            var user = await GetCurrentUserAsync();
            if (user == null) return Forbid();

            // Create a new message to save to the database
            MessageModel newMessage = new MessageModel(message.Content)
            {
                MessageText = message.Content,
                UserId = user.Id,
                User = user
            };

            // Save the new message
            await _context.AddAsync(newMessage);
            await _context.SaveChangesAsync();

            MessageViewModel model = new MessageViewModel(newMessage);


            // Call the client method 'addChatMessage' on all clients in the
            // "MainChatroom" group.
//            _hubContext.Clients.Group("MainChatroom").InvokeAsync().
//            this.Clients.Group("MainChatroom").AddChatMessage(model);
            //for a single group
            await _hubContext.Clients.Group("groupName").InvokeAsync("groupMessage", model);

//            await _hubContext.Clients.All.InvokeAsync("Send", message);
            return new NoContentResult();
        }
    }
}