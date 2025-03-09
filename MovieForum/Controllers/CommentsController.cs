using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieForum.Data;
using MovieForum.Models;

namespace MovieForum.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly MovieForumContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(MovieForumContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Removed actions
        // GET: Comments
        // GET: Comments/Details/5
        // GET: Comments/Edit/5
        // POST: Comments/Edit/5
        // GET: Comments/Delete/5
        // POST: Comments/Delete/5

        // GET: Comments/Create
        public IActionResult Create(int discussionId)
        {
            ViewData["DiscussionId"] = discussionId;
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Content,CreateDate,DiscussionId")] Comment comment)
        {
            
            comment.ApplicationUserId = _userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();

                return RedirectToAction("GetDiscussion", "Home", new { id = comment.DiscussionId });
            }

            ViewData["DiscussionId"] = comment.DiscussionId;

            return View(comment);
        }
    }
}
