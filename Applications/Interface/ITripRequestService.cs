using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Interface
{
    public interface ITripRequestService
    {
        Task<bool> CreateTripAsync(TripDTO trip);

        Task<IEnumerable<TripDTO>> GetTripsByTgLinkAsync(string tglink);

        Task<IEnumerable<TripDTO>> FindTripsAsync(TripDTO trip);

        Task<bool> EditTripAsync(TripDTO trip, int id);

        Task<bool> AddPassengers(int id, UserDTO passenger);

        Task<bool> CloseTrip(int id);
    }
}
