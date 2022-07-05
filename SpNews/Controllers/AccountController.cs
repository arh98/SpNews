using Microsoft.AspNetCore.Mvc;
using SpNews.Data.Ripositories;
using SpNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpNews.Controllers
{
    public class AccountController : Controller
    {
        private IUser _user;
        public AccountController(IUser user)
        {
            _user = user;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModels register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            if (_user.IsExistUserEmail(register.Email))
            {
                ModelState.AddModelError("Email", "Already Used Email");
                return View(register);
            }
            User user = new User()
            {
                Email = register.Email,
                Password = register.Password,
                IsAdmin = false,
                IsBanned = false
            };
            _user.AddUser(user);

            return View("SuccessRegister" , register);
        }
    }
}
