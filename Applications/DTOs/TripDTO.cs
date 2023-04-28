using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DTOs
{
    public class TripDTO
    {
        public int Id { get; set; }

        public UserDTO Driver { get; set; }

        public IEnumerable<UserDTO> Passengers { get; set; }

        public DateTime? TripDate { get; set; }

        public StatusDTO Status { get; set; }

        public DestinationDTO Destination { get; set; }
    }
}
