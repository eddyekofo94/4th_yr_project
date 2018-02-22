using System;
using System.Collections.Generic;
using mlm.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mlm.Models;
using mlm.Models.Friendship;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace mlm.Controllers
{
    [Route("api/[controller]")]
    public class FriendsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FriendsController(ApplicationDbContext ctx,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = ctx;
        }

//        POST
        [HttpPost, Route("[action]")]
        public async Task<IActionResult> AddFriend(string item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var users = from u in _context.Users
                select u;
            
            if (!String.IsNullOrEmpty(item))
            {
                users = users.Where(u => u.Email.Contains(item));
            }

            var result = await users.ToListAsync();
//
            var friendRequest = new Friends()
            {
//                User = users;
                Friendships = result
            };
            
            // Save the new friendship to db
            await _context.AddAsync(friendRequest);
            await _context.SaveChangesAsync();
//            user.SentFriendRequests.Add(friendRequest);
         
            return Ok(friendRequest);
//            View();
        }
    }
}