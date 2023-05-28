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
using System.Xml.Linq;

namespace Applications.Implementation
{
    public class DayRequestService : IDayRequestService
    {

        private readonly CarPollDbContext _context;
        private readonly IMappers _mappers;

        public DayRequestService(CarPollDbContext context, IMappers mappers)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mappers = mappers;
        }

        public async Task<int> CreateDayAsync(DayDTO day)
        {
            var newProfile = new Day()
            {
                Days = day.Days,
                UserId = day.User.Id,
                Seats = day.Seats,
                DestinationId = day.Destination.Id
            };
            _context.Days.Add(newProfile);
            await _context.SaveChangesAsync();
            return newProfile.Id;
        }

        public async Task<IEnumerable<DayDTO>> GetAllDayAsync()
        {
            var days = _context.Days.AsNoTracking();
            if (days != null)
            {
                var daysDTO = new List<DayDTO>();
                foreach (var day in days)
                {
                    daysDTO.Add(await _mappers.GetDay(day));
                }
                return daysDTO;
            }
            return null;
        }

        public async Task<DayDTO> GetDayByIdAsync(int id)
        {
            var day = await _context.Days.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
            if (day != null)
            {
                return await _mappers.GetDay(day);
            }
            return null;
        }

        public async Task<DayDTO> GetDayByUserIdAsync(int userId)
        {
            var day = await _context.Days.AsNoTracking().FirstOrDefaultAsync(d => d.UserId == userId);
            if (day != null)
            {
                return await _mappers.GetDay(day);
            }
            return null;
        }
    }
}
