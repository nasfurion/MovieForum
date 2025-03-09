using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieForum.Data;
using MovieForum.Models;

namespace MovieForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieForumContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(MovieForumContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var discussions = await _context.Discussion
                .Include(d => d.Comments)
                .Include(d => d.ApplicationUser)
                .OrderByDescending(d => d.CreateDate)
                .ToListAsync();

            return View(discussions);
        }

        public async Task<IActionResult> GetDiscussion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discussion = await _context.Discussion
                .Include(d => d.ApplicationUser)
                .Include(c => c.Comments)
                    .ThenInclude(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }
            
            return View(discussion);
        }

        public async Task<IActionResult> Profile(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            
            var discussions = await _context.Discussion
                .Where(d => d.ApplicationUserId == id)
                .OrderByDescending(d => d.CreateDate)
                .Include(d=>d.Comments)
                .ToListAsync();

            ProfileViewModel profile = new ProfileViewModel
            {
                User = user,
                Discussions = discussions
            };

            return View(profile);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
