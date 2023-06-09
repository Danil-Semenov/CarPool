﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        public UserDTO User { get; set; }

        public ScoreDTO Score { get; set; }

        public TripDTO Trip { get; set; }
    }
}
