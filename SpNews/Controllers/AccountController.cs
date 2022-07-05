using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SpNews.Data.Ripositories;
using SpNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        #region Register
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
        #endregion
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            /////////////////fix
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = _user.GetUserForLogin(login.Email, login.Password);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Information Incorrect");
                return View(login);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("IsAdmin" ,user.IsAdmin.ToString())

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
           
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
    }
}
