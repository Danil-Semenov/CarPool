﻿using Applications.DB;
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

        public async Task<bool> AddPassengers(int id, int passengerId)
        {
            var editProfile = await _context.Trips.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            _context.Trips.Update(editProfile);
            if (editProfile != null)
            {
                var days = await _context.Days.AsNoTracking().SingleOrDefaultAsync(u => u.Id == editProfile.Days);
                var plase = days.Seats;
                if (editProfile.Passengers1 > 0 && plase > 0)
                {
                    editProfile.Passengers1 = passengerId;
                    await _context.SaveChangesAsync();
                    return true;
                }
                if (editProfile.Passengers2 > 0 && plase > 1)
                {
                    editProfile.Passengers2 = passengerId;
                    await _context.SaveChangesAsync();
                    return true;
                }
                if (editProfile.Passengers3 > 0 && plase > 2)
                {
                    editProfile.Passengers3 = passengerId;
                    await _context.SaveChangesAsync();
                    return true;
                }
                if (editProfile.Passengers4 > 0 && plase > 3)
                {
                    editProfile.Passengers4 = passengerId;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> DeletePassengers(int id, int passengerId)
        {
            var editProfile = await _context.Trips.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            _context.Trips.Update(editProfile);
            if (editProfile != null)
            {
                if (editProfile.Passengers1 == passengerId)
                {
                    editProfile.Passengers1 = 0;
                    await _context.SaveChangesAsync();
                    return true;
                }
                if (editProfile.Passengers2 == passengerId)
                {
                    editProfile.Passengers2 = 0;
                    await _context.SaveChangesAsync();
                    return true;
                }
                if (editProfile.Passengers3 == passengerId)
                {
                    editProfile.Passengers3 = 0;
                    await _context.SaveChangesAsync();
                    return true;
                }
                if (editProfile.Passengers4 == passengerId)
                {
                    editProfile.Passengers4 = 0;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> CloseTrip(int id, int userId)
        {
            var editProfile = await _context.Trips.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            _context.Trips.Update(editProfile);
            
            if (editProfile != null && user != null)
            {
                editProfile.Status = user.RoleId.Value == 1 ? 3:4;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<int> CreateTripAsync(TripDTO trip)
        {
            var newProfile = new Trip()
            {
                Driver = trip.Driver.Id,
                //Passengers = trip.Passengers.First().Id,
                //TripDate = trip.TripDate,
                Status = trip.Status.Id,
                Destination = trip.Destination.Id,
                //Metro = trip.Metro.Id,
                Days =  trip.Day.Id,
            };

            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == trip.Driver.Id);
            if(user != null && user.MetroId >0)
            {
                newProfile.Metro = user.MetroId;
            }
            else
            {
                new ArgumentException("Driver.Metro");
            }
            _context.Trips.Add(newProfile);
            await _context.SaveChangesAsync();
            return newProfile.Id;
        }

        public async Task<bool> EditTripAsync(TripDTO trip, int id)
        {
            var editProfile = await _context.Trips.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            _context.Trips.Update(editProfile);
            if (editProfile != null)
            {
                editProfile.Driver = trip.Driver.Id;
                //editProfile.Passengers = trip.Passengers.First().Id;
                editProfile.TripDate = trip.TripDate;
                editProfile.Status = trip.Status.Id;
                editProfile.Destination = trip.Destination.Id;
                editProfile.Metro = trip.Metro.Id;
                editProfile.Days = trip.Day.Id;
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
            var users = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.TgLink == tglink);
            if (users != null)
            {
                var trips = _context.Trips.AsNoTracking().Where(u => u.Passengers1 == users.Id || u.Driver == users.Id || u.Passengers2 == users.Id || u.Passengers3 == users.Id || u.Passengers4 == users.Id);
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
