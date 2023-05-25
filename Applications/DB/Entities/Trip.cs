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

        public int? Driver { get; set; }

        public int? Passengers1 { get; set; }

        public int? Passengers2 { get; set; }

        public int? Passengers3 { get; set; }

        public int? Passengers4 { get; set; }

        public DateTime? TripDate { get; set; }

        public int? Status { get; set; }

        public int? Destination { get; set; }

        public int? Metro { get; set; }

        public int? Days { get; set; }
    }
}
