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
        Task<int> CreateTripAsync(TripDTO trip);

        Task<IEnumerable<TripDTO>> GetTripsByTgLinkAsync(string tglink);

        Task<IEnumerable<TripDTO>> FindTripsAsync(TripDTO trip);

        Task<bool> EditTripAsync(TripDTO trip, int id);

        Task<bool> AddPassengers(int id, int passengerId);

        Task<bool> DeletePassengers(int id, int passengerId);

        Task<bool> CloseTrip(int id, int userId);
    }
}
