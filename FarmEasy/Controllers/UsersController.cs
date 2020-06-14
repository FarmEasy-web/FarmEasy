using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmEasy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FarmEasy.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<UserMaster> _userManager;

        public UsersController(UserManager<UserMaster> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
           var users=_userManager.Users.ToList();
            return View(users);
        }
    }
}