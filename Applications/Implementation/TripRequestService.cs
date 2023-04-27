using Applications.DTOs;
using Applications.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Implementation
{
    public class TripRequestService : ITripRequestService
    {
        public Task<bool> AddPassengers(int id, UserDTO passenger)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CloseTrip(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateTripAsync(TripDTO trip)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditTripAsync(TripDTO trip, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TripDTO>> FindTripsAsync(TripDTO trip)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TripDTO>> GetTripsByTgLinkAsync(string tglink)
        {
            throw new NotImplementedException();
        }
    }
}
