using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Core.Inrefaces
{
    public interface IAccountManager
    {
        public Task<Tuple<bool,string[]>> CreateUserAsync(ApplicationUser user,string password);
        public Task<ApplicationUser> GetUserByIdAsync(string UserId);
        public Task<ApplicationUser> GetUserByNameAsync(string UserName);
        public Task<bool> CheckUserPasswordAsync(ApplicationUser user,string password);
        public Task<Tuple<bool, string[]>> DeleteUserAsync(ApplicationUser user);
        public List<ApplicationUser> GetAllUsersAsync();
    }
}
