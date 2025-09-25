using CakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task  Register (User user);
        
        Task<bool> SaveChangesAsync();
    }
}
