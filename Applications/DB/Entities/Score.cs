using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DB.Entities
{
    public class Score
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? RoleId { get; set; }
    }
}
