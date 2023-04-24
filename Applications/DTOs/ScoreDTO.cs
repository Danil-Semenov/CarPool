using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DTOs
{
    public class ScoreDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RoleDTO Role { get; set; }
    }
}
