using System;
using System.Collections.Generic;
using mlm.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mlm.Models;
using mlm.Models.Friendship;
using Microsoft.AspNetCore.Mvc;

namespace mlm.Controllers
{
    public class AddFriendController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddFriendController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        // GET
//        [HttpPost]
//        public IActionResult AddFriend(ApplicationUser user)
//        {
//            var users = from u in _context.Users
//                select u;
//            if (!String.IsNullOrEmpty(user))
//            {
//                users = users.Where(u => u.Email.Contains(user));
//            }
//
//            var friendRequest = new ApplicationUser()
//            {
//                Friends = new List<ApplicationUser>();
//            };
//            user.SentFriendRequests.Add(friendRequest);
//
//            return Ok();
//            View();
//        }
    }
}