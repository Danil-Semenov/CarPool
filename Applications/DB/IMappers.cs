using Applications.DB.Entities;
using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DB
{
    public interface IMappers
    {
        public Task<UserDTO> GetUser(User user);

        public Task<TripDTO> GetTrip(Trip trip);

        public Task<RoleDTO> GetRole(Role role);

        public Task<ScoreDTO> GetScore(Score score);

        public Task<DestinationDTO> GetDestination(Destination destination);

        public Task<StatusDTO> GetStatus(Status status);

        public Task<MetroDTO> GetMetro(Metro metro);

        public Task<DayDTO> GetDay(Day day);

        public Task<ReviewDTO> GetReview(Review review);
    }
}
