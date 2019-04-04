using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using What_A_Movie.ViewModels;

namespace What_A_Movie.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserManagement()
        {
            var users = _userManager.Users;
            return View(users);
        }
        public IActionResult AddUser()
        {
            return View();
        }
        
      
        public async Task<IActionResult> UpdateUser(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);

                if (user == null)
                return RedirectToAction("UserManagement", _userManager.Users);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if (!ModelState.IsValid) return View(addUserViewModel);
            IdentityUser user = new IdentityUser()
            {
                UserName = addUserViewModel.UserName,
                Email = addUserViewModel.Email,
            };
            IdentityResult result = await _userManager.CreateAsync(user, addUserViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("UserManagement", _userManager.Users);
            }
            foreach(IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(addUserViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateUser(string id, string username, string email)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                user.UserName = username;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded) return RedirectToAction("UserManagement", _userManager.Users);

                ModelState.AddModelError("", "User not updated, something went wrong.");
                return View(user);
            }
            return RedirectToAction("UserManagement", _userManager.Users);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("UserManagement");
                else
                    ModelState.AddModelError("", "Something went wrong while deleting this user.");
            }
            else
            {
                ModelState.AddModelError("", "This user can't be found");
            }
            return View("UserManagement", _userManager.Users);
        }
    }
}