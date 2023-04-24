using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DTOs
{
    public class DayDTO
    {
        public int Id { get; set; }

        public DateTime Days { get; set; }

        public int Seats { get; set; }

        public MetroDTO Metro { get; set; }
    }
}
