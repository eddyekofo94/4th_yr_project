using System;
using System.Collections.Generic;
using mlm.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mlm.Models;
using mlm.Models.Friendship;
using Microsoft.AspNetCore.Authorization;
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

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


//        POST
        [Authorize]
        [HttpPost, Route("[action]")]
        public async Task<IActionResult> AddFriend(string item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var users = from u in _context.Users
                select u;
            var friendship = from f in _context.Friends
                select f;

            // Get the current user
            var user = await GetCurrentUserAsync();
            if (user == null) return Forbid();

            
                friendship = friendship.Where(u => u.FriendEmail.Contains(item));

                if (friendship.ToString().Equals(item))
                {
                    Console.Write(">>>>>>>>>>>>>>>>>>>: ALREADY FRIENDS");
                }
            

            if (!String.IsNullOrEmpty(item))
            {
                users = users.Where(u => u.Email.Contains(item));
//                var result = await users.ToListAsync();
                foreach (var u in users)
                {
                    var friendRequest = new Friends()
                    {
                        UserId = user.Id,
                        User = user,
                        FriendEmail = u.Email,
                        Friendships = new List<ApplicationUser>()
                    };
                    friendRequest.Friendships.Add(u);
                    // Save the new friendship to db
                    await _context.AddAsync(friendRequest);
                }
            }

            await _context.SaveChangesAsync();
//            user.SentFriendRequests.Add(friendRequest);

            return new NoContentResult();
//            View();
        }
    }
}