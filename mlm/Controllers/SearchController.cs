using System;
using System.Linq;
using System.Threading.Tasks;
using mlm.Data;
using mlm.Models;
using mlm.Models.SearchViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace mlm.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> SearchUser(string searchString)
        {
            var users = from u in _context.Users
                select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.Email.Contains(searchString));
            }

            foreach (var user in users)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>> " + user);
            }

            var usersResult = new SearchUserViewModel();
            usersResult.Users = await users.ToListAsync();
            return View(usersResult);
        }
    }
}