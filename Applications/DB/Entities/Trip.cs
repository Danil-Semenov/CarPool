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

        public int Driver { get; set; }

        public int Passengers { get; set; }

        public DateTime TripDate { get; set; }

        public int Status { get; set; }

        public int Destination { get; set; }
    }
}
