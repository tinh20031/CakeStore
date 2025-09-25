using CakeStore.Data.Interfaces;
using CakeStoreAPI.Data;
using CakeStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CakeStoreDbContext _context;
        public UserRepository(CakeStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }
        public async Task Register (User user)
        {
             await _context.Users.AddAsync(user);
        }


    }
}

