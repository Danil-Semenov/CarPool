using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DB.Entities
{
    public class Day
    {
        public int Id { get; set; }

        public DateTime Days { get; set; }

        public int Seats { get; set; }

        public int MetroId { get; set; }
    }
}
