using Applications.DB.Entities;
using Applications.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DB
{
    public class Mappers : IMappers
    {
        private readonly CarPollDbContext _context;

        public Mappers(CarPollDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<TripDTO> GetTrip(Trip trip)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetUser(User user)
        {
            var result = new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Phone = user.Phone,
                TgLink = user.TgLink,
                Benefits = user.Benefits,
                Capacity = user.Capacity,
                RegistrationDate = user.RegistrationDate,
            };

            var role = await _context.Roles.AsNoTracking().SingleOrDefaultAsync(r => r.Id == user.RoleId);
            if (role != null)
            {
                result.Role = new RoleDTO()
                {
                    Id = role.Id,
                    Name = role.Name
                };
            } 
            return result;
        }
    }
}
