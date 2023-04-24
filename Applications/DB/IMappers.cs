using Applications.DB.Entities;
using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DB
{
    interface IMappers
    {
        public Task<UserDTO> GetUser(User user);

        public Task<TripDTO> GetTrip(Trip trip);
    }
}
