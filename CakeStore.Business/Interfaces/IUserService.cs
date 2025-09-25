using CakeStore.Business.DTO.Product;
using CakeStore.Business.DTO.User;
using CakeStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<bool> UpdateUserAsync(int id, UpdateUserDto user, IFormFile Image);
    
        Task<bool> DeleteUserAsync(int id);
       

    }
}
