using DAL.Core.Inrefaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Core
{
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountManager(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<bool> CheckUserPasswordAsync(ApplicationUser user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
        }

        public async Task<Tuple<bool, string[]>> CreateUserAsync(ApplicationUser user,string password)
        {
           var result= await userManager.CreateAsync(user, password);
           return Tuple.Create(result.Succeeded,result.Errors.Select(a=>a.Description).ToArray());
        }

        public async Task<Tuple<bool, string[]>> DeleteUserAsync(ApplicationUser user)
        {
            var result= await userManager.DeleteAsync(user);
            return Tuple.Create(result.Succeeded, result.Errors.Select(a => a.Description).ToArray());
        }

        public List<ApplicationUser> GetAllUsersAsync()
        {
            return userManager.Users.ToList();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string UserId)
        {
            return await userManager.FindByIdAsync(UserId);
        }

        public async Task<ApplicationUser> GetUserByNameAsync(string UserName)
        {
            return await userManager.FindByNameAsync(UserName);
        }
    }
}
