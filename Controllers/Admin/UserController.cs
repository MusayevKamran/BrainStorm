﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BrainStorm.Areas.Identity.Data;
using BrainStorm.Areas.Identity.Services;
using BrainStorm.Helpers;
using BrainStorm.Models;
using BrainStorm.Models.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrainStorm.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        BrainStormDbContext _context;
        UserService _userService;
        private readonly UserManager<BrainStormUser> _userManager;

        public UserController(BrainStormDbContext context, UserManager<BrainStormUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Route("admin/user")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Xos Gelmisiniz";
            _userService = new UserService(_context);
            var Id = _userManager.GetUserId(HttpContext.User);
            BrainStormUser BrainStormUser = _userService.GetUsersById(Guid.Parse(Id));
            if (BrainStormUser.AvatarImage == null)
            {
                BrainStormUser.AvatarImage = "images/user/default_user.png";
                _context.SaveChanges();
            }
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