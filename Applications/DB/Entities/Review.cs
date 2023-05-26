using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DB.Entities
{
    public class Review
    {
        public int Id { get; set; }

        public long? User { get; set; }

        public int? Score { get; set; }

        public int? Trip { get; set; }
    }
}
