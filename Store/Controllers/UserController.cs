using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserModel _user)
        {
            if (ModelState.IsValid)
            {

            }
                return View("Register");
        }

        public IActionResult Detail()
        {
            return View("Detail");
        }

        public IActionResult Login()
        {
            return View("Detail");
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {

            }
            return View("Register");
        }



    }
}
