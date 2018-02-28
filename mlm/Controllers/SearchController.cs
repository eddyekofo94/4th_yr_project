using System;
using System.Linq;
using System.Threading.Tasks;
using mlm.Data;
using mlm.Models;
using mlm.Models.SearchViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace mlm.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SearchController(ApplicationDbContext ctx,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = ctx;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpGet]
        public async Task<IActionResult> SearchUser(string searchString)
        {
            var users = from u in _context.Users
//                orderby u.LastName
                select u;

            // Get the current user
            var currentUser = await GetCurrentUserAsync();
            if (currentUser == null) return Forbid();

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.Email.Contains(searchString));
//                users = users.Where(u => !u.Email.Contains(currentUser.Email));
            }
            
            // Excludes the current user... TODO: is there a better way?
            var result = users.Where(u => !u.Id.Contains(currentUser.Id));

            var usersResult = new SearchUserViewModel
            {
                Users = await result.ToListAsync()
            };
            return View(usersResult);
        }
    }
}