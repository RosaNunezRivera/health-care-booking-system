using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEntities.Entities
{
    public class Availability
    {
        [Key]
        public int AvailabilityId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        public string AvailabilityTime { get; set; }

        // one availability can be included in multiple Bookings - navigation property in E
        public ICollection<Booking> Bookings { get; set; }
    }
}
