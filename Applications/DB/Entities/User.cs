using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DB.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public int RoleId { get; set; }

        public string Phone { get; set; }

        public string TgLink { get; set; }

        public string Benefits { get; set; }

        public int Capacity { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
