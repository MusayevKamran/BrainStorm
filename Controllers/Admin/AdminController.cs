using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainStorm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrainStorm.Controllers
{
    //[Authorize(Roles = UserStatus.ADMIN)]
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}