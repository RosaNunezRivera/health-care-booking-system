using BEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEntities.Context
{
    public class PatientBookingContext : DbContext
    {
        public PatientBookingContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=HealthCareBookingSystemTest;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        //To create the tables
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Availability>()
            //.HasKey(a => new { a.AvailabilityId, a.DoctorID });

            modelBuilder.Entity<Booking>()
                 .HasOne(b => b.Doctor)
                 .WithMany()
                 .HasForeignKey(b => b.BookingDoctorID)
                 .OnDelete(DeleteBehavior.Restrict);  
        }
    }
}
