using Applications.DB;
using Applications.DB.Entities;
using Applications.DTOs;
using Applications.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Implementation
{
    public class UserRequestService : IUserRequestService
    {
        private readonly CarPollDbContext _context;
        private readonly IMappers _mappers;

        public UserRequestService(CarPollDbContext context, IMappers mappers)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mappers = mappers;
        }

        public async Task<bool> CreateProfileAsync(UserDTO user)
        {
            var newProfile = new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Phone = user.Phone,
                TgLink = user.TgLink,
                Benefits = user.Benefits,
                Capacity = user.Capacity,
                RegistrationDate = user.RegistrationDate,
                RoleId = user.Role.Id
            };
            _context.Users.Add(newProfile);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditProfileAsync(UserDTO user, int id)
        {
            var editProfile = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            _context.Users.Update(editProfile);
            editProfile.FirstName = user.FirstName;
            editProfile.Phone = user.Phone;
            editProfile.TgLink = user.TgLink;
            editProfile.Benefits = user.Benefits;
            editProfile.Capacity = user.Capacity;
            editProfile.RegistrationDate = user.RegistrationDate;
            editProfile.RoleId = user.Role.Id;
            //_context.Users.Update(editProfile);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<RoleDTO> GetRoleByTgLinkAsync(string tglink)
        {
            var profile = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.TgLink == tglink);
            var user = await _mappers.GetUser(profile);
            return user.Role;
        }

        public async Task<UserDTO> GetFirstAsync()
        {
            var profile = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u=> u.Id >0);
            var user = await _mappers.GetUser(profile);
            return user;
        }
    }
}
