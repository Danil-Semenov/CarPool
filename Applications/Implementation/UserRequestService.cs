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

        public async Task<long> CreateProfileAsync(UserDTO user)
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
            foreach (var item in user.Metros)
            {
                _context.UserMetro.Add(new UserMetro()
                {
                    UserId = user.Id,
                    MetroId = item.Id
                });
            }
            await _context.SaveChangesAsync();
            return newProfile.Id;
        }

        public async Task<bool> EditProfileAsync(UserDTO user, long id)
        {
            var editProfile = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            _context.Users.Update(editProfile);
            if (!string.IsNullOrEmpty(user.FirstName))
                editProfile.FirstName = user.FirstName;
            if (!string.IsNullOrEmpty(user.Phone))
                editProfile.Phone = user.Phone;
            if (!string.IsNullOrEmpty(user.TgLink))
                editProfile.TgLink = user.TgLink;
            if (!string.IsNullOrEmpty(user.Benefits))
                editProfile.Benefits = user.Benefits;
            if (user.Capacity >0 )
                editProfile.Capacity = user.Capacity;
            if (user.Role?.Id > 0)
                editProfile.RoleId = user.Role.Id;
            //if (user.Metro?.Id > 0)
            //    editProfile.MetroId = user.Metro.Id;
            //_context.Users.Update(editProfile);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<RoleDTO> GetRoleByIdAsync(long id)
        {
            var profile = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            var user = await _mappers.GetUser(profile);
            return user.Role;
        }

        public async Task<UserDTO> GetFirstAsync()
        {
            var profile = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u=> u.Id >0);
            var user = await _mappers.GetUser(profile);
            return user;
        }

        public async Task<bool> AddMetroByUserIdAsync(long userid, int metroId)
        {
            _context.UserMetro.Add(new UserMetro()
            {
                UserId = userid,
                MetroId = metroId
            });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMetroByUserIdAsync(long userid, int metroId)
        {
            var profile = await _context.UserMetro.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == userid || u.MetroId == metroId);
            _context.UserMetro.Remove(profile);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
