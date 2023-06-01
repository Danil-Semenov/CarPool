using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DTOs
{
    public class TripFilterDTO
    {
        public DateTime? DateTrip { get; set; }

        public int? Metro { get; set; }

        public int? Destination { get; set; }
    }
}
