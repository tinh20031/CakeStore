using CakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Data.Interfaces
{
    public interface IAuthRepository
    {
        Task<bool> Register(User user);
        Task <User> Login( string Email);
        Task<User> SaveRefreshTokens(int userId, string refreshTokens);
        Task<User> GetUserId(int  userId);
        Task<User> GetUser (int userId);
        Task<User> UpdateUser (User user);  
        Task<bool> SaveChangesAsync();
    }
}
