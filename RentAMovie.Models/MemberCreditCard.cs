﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models
{
    public class MemberCreditCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public Member Member { get; set; }
    }
}
