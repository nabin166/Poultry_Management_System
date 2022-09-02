using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PoultryVersion.Models;
using System.Security.Claims;

namespace PoultryVersion.Controllers
{
    public class AccountController : Controller
    {
        private readonly PoultryUpdatedContext _context;

        public AccountController(PoultryUpdatedContext poultryUpdatedContext)
        {
            _context = poultryUpdatedContext;
        }

        public IActionResult Index()
        {
            return View();
        
        }
        [HttpPost]
        public IActionResult Login(string Email ,string Password)
        {
            TblUser user = _context.TblUsers.Where(x => x.Email == Email).FirstOrDefault();

            ClaimsIdentity identity = null!;
            bool isauthenticate = false;

            if(user != null)
            {
                if(user.Password == Password)
                {
                    identity = new ClaimsIdentity(new[]
                   {
                        new Claim(ClaimTypes.Name , Email),
                        new Claim(ClaimTypes.Role , "Admin")
                    },CookieAuthenticationDefaults.AuthenticationScheme );
                    isauthenticate = true;

                    if (isauthenticate)
                    {
                        var principal = new ClaimsPrincipal(identity);
                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
                        return RedirectToAction("Index", "Home");
                    }


                }
                else
                {
                    return RedirectToAction("Index", "Account");
                }


            }

            return RedirectToAction("Index", "Account");
        }

        public IActionResult Signout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Account");
        }

    }

}
