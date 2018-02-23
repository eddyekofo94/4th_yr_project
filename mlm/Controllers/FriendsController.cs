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
    [Authorize]
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

// TODO: Get all of user's friends
//        [HttpGet]
//        public async Task<IActionResult> GetFriends(string item)
//        {
//        }

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

            // Get the current user
            var currentUser = await GetCurrentUserAsync();
            if (currentUser == null) return Forbid();

            if (!String.IsNullOrEmpty(item))
            {
                users = users.Where(u => u.Email.Contains(item));
            }

// TODO: Check if current user is not a friend with the added user
            Friendship friendship = new Friendship()
            {
                UserId = currentUser.Id
            };
            foreach (var u in users)
            {
                friendship.User = u;
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>: ID " + friendship.FriendshipId);
                friendship.FriendId = u.Id;
                friendship.FriendEmail = u.Email;
            }

            await _context.AddAsync(friendship);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        //TODO: Test this methos if user's cand delete friend
        [HttpPost]
        public async Task<IActionResult> DeleteFriend(string item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var friendships = from u in _context.Friendships
                select u;
            // Get the current user
            var currentUser = await GetCurrentUserAsync();
            if (currentUser == null) return Forbid();

            if (!String.IsNullOrEmpty(item))
            {
                friendships = friendships.Where(u => u.FriendEmail.Contains(item));
                foreach (var friend in friendships)
                {
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>: " + friend.FriendEmail + "Friendship ID: " +
                                      friend.FriendshipId);
                    currentUser.Friendships.Remove(friend);
                }

                await _context.AddAsync(friendships);
                await _context.SaveChangesAsync();
            }

            return new NoContentResult();
        }
    }
}