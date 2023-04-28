using Applications.DB;
using Applications.DB.Entities;
using Applications.DTOs;
using Applications.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Implementation
{
    public class TripRequestService : ITripRequestService
    {
        private readonly CarPollDbContext _context;
        private readonly IMappers _mappers;

        public TripRequestService(CarPollDbContext context, IMappers mappers)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mappers = mappers;
        }

        public async Task<bool> AddPassengers(int id, UserDTO passenger)
        {
            var editProfile = await _context.Trips.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            _context.Trips.Update(editProfile);
            if (editProfile != null)
            {
                editProfile.Passengers = passenger.Id;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CloseTrip(int id)
        {
            var editProfile = await _context.Trips.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            _context.Trips.Update(editProfile);
            if (editProfile != null)
            {
                editProfile.Status = 2;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CreateTripAsync(TripDTO trip)
        {
            var newProfile = new Trip()
            {
                Id = trip.Id,
                Driver = trip.Driver.Id,
                Passengers = trip.Passengers.First().Id,
                TripDate = trip.TripDate,
                Status = trip.Status.Id,
                Destination = trip.Destination.Id
            };
            _context.Trips.Add(newProfile);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditTripAsync(TripDTO trip, int id)
        {

            var editProfile = await _context.Trips.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            _context.Trips.Update(editProfile);
            if (editProfile != null)
            {
                editProfile.Driver = trip.Driver.Id;
                editProfile.Passengers = trip.Passengers.First().Id;
                editProfile.TripDate = trip.TripDate;
                editProfile.Status = trip.Status.Id;
                editProfile.Destination = trip.Destination.Id;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TripDTO>> FindTripsAsync(TripDTO trip)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TripDTO>> GetTripsByTgLinkAsync(string tglink)
        {
            var users = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.TgLink == tglink);
            if (users != null)
            {
                var trips = _context.Trips.AsNoTracking().Where(u => u.Passengers == users.Id || u.Driver == users.Id);
                if (trips != null)
                {
                    var tripsDTO = new List<TripDTO>();
                    foreach (var trip in trips)
                    {
                        tripsDTO.Add(await _mappers.GetTrip(trip));
                    }
                    return tripsDTO;
                }
            }
            return null;
        }
    }
}
