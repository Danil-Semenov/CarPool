using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DB.Entities
{
    public class Trip
    {
        public int Id { get; set; }

        public long? Driver { get; set; }

        public long? Passengers1 { get; set; }

        public long? Passengers2 { get; set; }

        public long? Passengers3 { get; set; }

        public long? Passengers4 { get; set; }

        public DateTime? TripDate { get; set; }

        public int? Status { get; set; }

        public int? Destination { get; set; }

        public int? Metro { get; set; }

        public int? Days { get; set; }
    }
}
