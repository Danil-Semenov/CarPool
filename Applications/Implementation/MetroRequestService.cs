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
    public class MetroRequestService : IMetroRequestService
    {
        private readonly CarPollDbContext _context;
        private readonly IMappers _mappers;

        public MetroRequestService(CarPollDbContext context, IMappers mappers)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mappers = mappers;
        }

        public async Task<int> CreateMetroAsync(string name)
        {
            var newProfile = new Metro()
            {
                Name = name
            };
            _context.Metro.Add(newProfile);
            await _context.SaveChangesAsync();
            return newProfile.Id;
        }

        public async Task<IEnumerable<MetroDTO>> GetAllMetroAsync()
        {
            var metros = _context.Metro.AsNoTracking();
            if (metros != null)
            {
                var metroDTO = new List<MetroDTO>();
                foreach (var metro in metros)
                {
                    metroDTO.Add(await _mappers.GetMetro(metro));
                }
                return metroDTO;
            }
            return null;
        }

        public async Task<MetroDTO> GetMetroByIdAsync(int id)
        {
            var metro = await _context.Metro.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (metro != null)
            {
                return await _mappers.GetMetro(metro);
            }
            return null;
        }


        public async Task<MetroDTO> GetMetroByNameAsync(string name)
        {
            var metro = await _context.Metro.AsNoTracking().FirstOrDefaultAsync(m => m.Name == name);


            if (metro != null)
            {
                return await _mappers.GetMetro(metro);
            }
            return null;
        }
    }
}
