using HRMangmentSystem.BusinessLayer.Helpers;
using HRMangmentSystem.BusinessLayer.IRepository;
using HRMangmentSystem.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMangmentSystem.BusinessLayer.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManger = userManager;
            _roleManager = roleManager;
        }
        public async Task CreateAdminAsync(ApplicationUser user, bool isSuperAdmin)
        {
            IdentityResult result = await _userManger.CreateAsync(user);

            if (result.Succeeded)
            {
                if (isSuperAdmin)
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin));
                    await _userManger.AddToRoleAsync(user, UserRoles.SuperAdmin);
                }
                else
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    await _userManger.AddToRoleAsync(user, UserRoles.Admin);
                }
            }
        }
    }
}
