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

        Task<IEnumerable<TripDTO>> GetTripsByUserIdAsync(long userId);

        Task<IEnumerable<TripDTO>> FindTripsAsync(TripFilterDTO filter);

        Task<bool> EditTripAsync(TripDTO trip, int id);

        Task<bool> AddPassengers(int id, long passengerId);

        Task<bool> DeletePassengers(int id, long passengerId);

        Task<bool> CloseTrip(int id, long userId);
    }
}
