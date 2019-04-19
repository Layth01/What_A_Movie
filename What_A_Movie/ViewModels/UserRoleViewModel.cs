using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using What_A_Movie.Models;

namespace What_A_Movie.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Users = new List<ApplicationUser>();
        }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}
