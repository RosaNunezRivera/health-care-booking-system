using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BEntities.Entities
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [MaxLength(50)]
        public string DoctorName { get; set; }

        [MaxLength(50)]
        public string DoctorEmail { get; set; }

        [MaxLength(50)]
        public string DoctorSpecialization { get; set; }

        // multiple booking with one Doctor - Navigation Property
        public ICollection<Booking> Bookings { get; set; }

        // multiple Availability with one doctor - Navigation Property
        public ICollection<Availability> Availabilites { get; set; }
    }
}
