﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEntities.Entities
{
    public class Pacient
    {
        [Key]
        public int PacientID { get; set; }

        [MaxLength(50)]
        public string PacientName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
