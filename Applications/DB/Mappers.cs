using Applications.DB.Entities;
using Applications.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Applications.DB
{
    public class Mappers : IMappers
    {
        private readonly CarPollDbContext _context;

        public Mappers(CarPollDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<DayDTO> GetDay(Day day)
        {
            var result = new DayDTO()
            {
                Id = day.Id,
                Seats = day.Seats
            };

            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(r => r.Id == day.UserId);
            if (user != null)
            {
                result.User = await GetUser(user);
            }
            var destination = await _context.Destinations.AsNoTracking().SingleOrDefaultAsync(r => r.Id == day.DestinationId);
            if (destination != null)
            {
                result.Destination = await GetDestination(destination);
            }

            return result;
        }

        public async Task<DestinationDTO> GetDestination(Destination destination)
        {
            return new DestinationDTO()
            {
                Id = destination.Id,
                Name = destination.Name
            };
        }

        public async Task<MetroDTO> GetMetro(Metro metro)
        {
            var result = new MetroDTO()
            {
                Id = metro.Id,
                Name = metro.Name
            };

            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(r => r.Id == metro.UserId);
            if (user != null)
            {
                result.User = await GetUser(user);
            }

            return result;
        }

        public async Task<ReviewDTO> GetReview(Review review)
        {
            var result = new ReviewDTO()
            {
                Id = review.Id
            };

            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(r => r.Id == review.User);
            if (user != null)
            {
                result.User = await GetUser(user);
            }
            var trip = await _context.Trips.AsNoTracking().SingleOrDefaultAsync(r => r.Id == review.Trip);
            if (trip != null)
            {
                result.Trip = await GetTrip(trip);
            }
            var score = await _context.Scores.AsNoTracking().SingleOrDefaultAsync(r => r.Id == review.Score);
            if (score != null)
            {
                result.Score = await GetScore(score);
            }
            return result;
        }

        public async Task<RoleDTO> GetRole(Role role)
        {
            return new RoleDTO()
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public async Task<ScoreDTO> GetScore(Score score)
        {
            var result = new ScoreDTO()
            {
                Id = score.Id,
                Name = score.Name
            };

            var role = await _context.Roles.AsNoTracking().SingleOrDefaultAsync(r => r.Id == score.RoleId);
            if (role != null)
            {
                result.Role = await GetRole(role);
            }
            return result;
        }

        public async Task<StatusDTO> GetStatus(Status status)
        {
            return new StatusDTO()
            {
                Id = status.Id,
                Name = status.Name
            };
        }

        public async Task<TripDTO> GetTrip(Trip trip)
        {
            var result = new TripDTO()
            {
                Id = trip.Id,
                TripDate = trip.TripDate
            };

            var driver = await _context.Users.AsNoTracking().SingleOrDefaultAsync(r => r.Id == trip.Driver);
            if (driver != null)
            {
                result.Driver = await GetUser(driver);
            }
            var passengers = await _context.Users.AsNoTracking().SingleOrDefaultAsync(r => r.Id == trip.Passengers);
            if (passengers != null)
            {
                result.Passengers = new List<UserDTO>() { await GetUser(passengers) };
            }
            var status = await _context.Status.AsNoTracking().SingleOrDefaultAsync(r => r.Id == trip.Status);
            if (status != null)
            {
                result.Status = await GetStatus(status);
            }
            var destination = await _context.Destinations.AsNoTracking().SingleOrDefaultAsync(r => r.Id == trip.Destination);
            if (destination != null)
            {
                result.Destination = await GetDestination(destination);
            }
            return result;
        }

        public async Task<UserDTO> GetUser(User user)
        {
            var result = new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Phone = user.Phone,
                TgLink = user.TgLink,
                Benefits = user.Benefits,
                Capacity = user.Capacity,
                RegistrationDate = user.RegistrationDate,
            };

            var role = await _context.Roles.AsNoTracking().SingleOrDefaultAsync(r => r.Id == user.RoleId);
            if (role != null)
            {
                result.Role = await GetRole(role);
            } 
            return result;
        }
    }
}
