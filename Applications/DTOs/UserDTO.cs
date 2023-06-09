﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public RoleDTO Role { get; set; }

        public string Phone { get; set; }

        public string TgLink { get; set; }

        public int? Bonus { get; set; }

        public string Benefits { get; set; }

        public int? Capacity { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public IEnumerable<MetroDTO> Metros { get; set; }
    }
}
