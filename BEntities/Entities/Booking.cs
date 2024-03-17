using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEntities.Entities
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [ForeignKey("Patient")]
        public int BookingPatientID { get; set; }

        [ForeignKey("Doctor")]
        public int BookingDoctorID { get; set; }

        [ForeignKey("Availability")]
        public int BookingAvailabilityId { get; set; }

        public DateTime BookingDate {  get; set; }

        // lazy loading of entities in EF
        public virtual Patient Patient { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Availability Availability { get; set; }
    }
}
