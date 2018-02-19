using System;
using System.Linq;
using System.Threading.Tasks;
using mlm.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mlm.Controllers
{
    [Route("api/[controller]")]
    public class SearchUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchUsersController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> SearchUser()
        {
//            Console.Write("This is called!!");
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string username = "";
            var users = from user in _context.Users
                select user;
            var allUsers = _context.Users.ToListAsync();
            foreach (var user in allUsers)
            {
                username = user.UserName;
                Console.WriteLine(username, user.Id, user.Email);
            }


            return View(await _context.Users.ToArrayAsync());
        }
    }
}