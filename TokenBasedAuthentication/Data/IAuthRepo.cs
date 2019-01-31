using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenBasedAuthentication.Models;

namespace TokenBasedAuthentication.Data
{
    public interface IAuthRepo
    {
        Task<User> Login(String UserName, string password);
        Task<User> Register(User user, string password);
        Task<bool> UserExists(string UserName);
    }
}
