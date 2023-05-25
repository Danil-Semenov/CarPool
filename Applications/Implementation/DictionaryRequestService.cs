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
    public class DictionaryRequestService : IDictionaryRequestService
    {
        private readonly CarPollDbContext _context;
        private readonly IMappers _mappers;

        public DictionaryRequestService(CarPollDbContext context, IMappers mappers)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mappers = mappers;
        }

        public async Task<IEnumerable<DestinationDTO>> GetAllDestinationAsync()
        {
            var items = _context.Destinations.AsNoTracking();
            if (items != null)
            {
                var itemsDTO = new List<DestinationDTO>();
                foreach (var item in items)
                {
                    itemsDTO.Add(await _mappers.GetDestination(item));
                }
                return itemsDTO;
            }
            return null;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRoleAsync()
        {
            var items = _context.Roles.AsNoTracking();
            if (items != null)
            {
                var itemsDTO = new List<RoleDTO>();
                foreach (var item in items)
                {
                    itemsDTO.Add(await _mappers.GetRole(item));
                }
                return itemsDTO;
            }
            return null;
        }

        public async Task<IEnumerable<StatusDTO>> GetAllStatusAsync()
        {
            var items = _context.Status.AsNoTracking();
            if (items != null)
            {
                var itemsDTO = new List<StatusDTO>();
                foreach (var item in items)
                {
                    itemsDTO.Add(await _mappers.GetStatus(item));
                }
                return itemsDTO;
            }
            return null;
        }

    }
}
