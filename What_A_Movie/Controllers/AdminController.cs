using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using What_A_Movie.Models;
using What_A_Movie.ViewModels;

namespace What_A_Movie.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
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
            var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                return RedirectToAction("UserManagement", _userManager.Users);

            var vm = new UpdateUserViewModel() { Id = user.Id, Email = user.Email, UserName = user.UserName, BirthDate = user.BirthDate, City = user.City, Country = user.Country };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if (!ModelState.IsValid) return View(addUserViewModel);

            var user = new ApplicationUser()
            {
               UserName = addUserViewModel.UserName,
               Email = addUserViewModel.Email,
               BirthDate = addUserViewModel.BirthDate,
               City = addUserViewModel.City,
               Country = addUserViewModel.Country

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
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel updateUserViewModel)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(updateUserViewModel.Id);
            if (user != null)
            {
                user.Email = updateUserViewModel.Email;
                user.UserName = updateUserViewModel.UserName;
                user.BirthDate = updateUserViewModel.BirthDate;
                user.City = updateUserViewModel.City;
                user.Country = updateUserViewModel.Country; ;
                

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded) return RedirectToAction("UserManagement", _userManager.Users);

                ModelState.AddModelError("", "User not updated, something went wrong.");
                return View(updateUserViewModel);
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