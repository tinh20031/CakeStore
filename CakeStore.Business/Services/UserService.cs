
using CakeStore.Business.DTO.Product;
using CakeStore.Business.DTO.User;
using CakeStore.Business.Interfaces;
using CakeStore.Data.Interfaces;
using CakeStore.Data.Repositories;
using CakeStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
       
        private readonly ICloudinaryService _cloudinaryService;
      
        public UserService(IUserRepository userRepository, ICloudinaryService cloudinaryService)
        {
            _userRepository = userRepository;
         
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var user = await _userRepository.GetAllUsers();
            return user.Select(u => new UserDto
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role,
                First_Name = u.First_Name,
                Last_Name = u.Last_Name,
                Address = u.Address,
                Phone = u.Phone,
                Image = u.Image
            }).ToList();

        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            return user == null ? null :new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Address = user.Address,
                Phone = user.Phone,
                Image = user.Image
            };
        }
        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto dto, IFormFile Image)
        {
            var existing = await _userRepository.GetUserById(id);
            if (existing == null) return false;
            if (!string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.First_Name) || string.IsNullOrWhiteSpace(dto.Last_Name) || string.IsNullOrWhiteSpace(dto.Address) || string.IsNullOrWhiteSpace(dto.Phone))
            {
                existing.Name = dto.Name;
                existing.First_Name = dto.First_Name;
                existing.Last_Name = dto.Last_Name;
                existing.Address = dto.Address;
                existing.Phone = dto.Phone;
             
            }
            string  uploadimage = null;
            if (uploadimage != null)
            {
               uploadimage = await _cloudinaryService.UploadImage(Image);
            }

               
            existing.Image = uploadimage;
            existing.Updated_At = DateTimeOffset.UtcNow;
            _userRepository.UpdateUser(existing);
            var result = await _userRepository.SaveChangesAsync();
            return result;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var existing = await _userRepository.GetUserById(id);
            if (existing == null) return false;
            _userRepository.DeleteUser(existing);
            var result = await _userRepository.SaveChangesAsync();
            return result;
        }
       

       
    }
}
