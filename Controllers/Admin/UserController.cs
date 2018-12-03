using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BrainStorm.Areas.Identity.Data;
using BrainStorm.Areas.Identity.Service;
using BrainStorm.Helpers;
using BrainStorm.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainStorm.Controllers
{
    public class UserController : Controller
    {
        BrainStormDbContext _context;
        UserService _userService;
        private readonly UserManager<BrainStormUser> _userManager;
        private readonly IHostingEnvironment _appEnvironment;

        public UserController(BrainStormDbContext context, UserManager<BrainStormUser> userManager, IHostingEnvironment hostingEnvironment)
        {
            this._context = context;
            this._userManager = userManager;
            this._appEnvironment = hostingEnvironment;
        }

        [Route("admin/user")]
        public IActionResult Index()
        {
            _userService = new UserService(_context);
            var Id = _userManager.GetUserId(HttpContext.User);
            BrainStormUser BrainStormUser = _userService.GetUsersById(Guid.Parse(Id));

            return View("index", BrainStormUser);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.BrainStormUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Row,Category,Content,PostCategory")] BrainStormUser BrainStormUser, IFormFile files)
        {
            _userService = new UserService(_context);
            var user = await _userService.GetUsersByIdAsync(BrainStormUser.Id);

            if (id != BrainStormUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.UpdateUsersAsync(id, user);
                    if (files != null && files.Length > 0)
                    {
                        ImageHelper imageHelper = new ImageHelper(_context);
                        imageHelper.UpdateImage(id, files, "user", user);
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(BrainStormUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(BrainStormUser);
        }


        private bool UsersExists(Guid id)
        {
            _userService = new UserService(_context);
            return _userService.UsersExists(id);
        }
    }
}