using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {

            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                // Model geçerli değilse direkt view'a dön
                return View(model);
            }

            IdentityUser user = await _userManager.FindByNameAsync(model.Name);
            if (user != null)
            {
                // Önce mevcut oturumu kapat
                await _signInManager.SignOutAsync();

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return Redirect(model.ReturnUrl ?? "/");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View(model);
        }


        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager
                    .AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    return RedirectToAction("Login", new { ReturnUl = "/"});
                }
            }
            else
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return View(model);
        }
    }


}