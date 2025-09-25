using CakeStore.Data.Interfaces;
using CakeStoreAPI.Data;
using CakeStoreAPI.Migrations;
using CakeStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly CakeStoreDbContext _context;
        public AuthRepository(CakeStoreDbContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string email)
        {
            return await _context.Users
                .AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<bool> Register(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(user.Email));
            }
            await _context.Users.AddAsync(user);

            return await SaveChangesAsync();

        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> SaveRefreshTokens(int userId, string refreshTokens)
        {
            var user = await _context.Users
                  .AsNoTracking().FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new ArgumentException("user not found ");
            }
            user.RefreshToken = refreshTokens;
            user.RefreshTokenExpiryTime = DateTimeOffset.UtcNow.AddDays(7);

       
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserId(int userId)
        {
            return await _context.Users
                .FindAsync(userId);
        }

        public async Task<User> GetUser (int userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<User> UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
